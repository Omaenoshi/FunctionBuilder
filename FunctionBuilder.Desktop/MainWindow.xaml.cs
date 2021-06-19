using FunctionBuilder.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OPZ.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double scroll = 1;
        public double Scroll
        {
            set
            {
                if (value <= 0) scroll = 1;
                else scroll = value;
            }

            get
            {
                return scroll;
            }
        }

        private double height;
        private double width;

        public MainWindow()
        {
            InitializeComponent();
            FunctionField.MouseWheel += FunctionField_ScaleWheel;
        }

        private void FunctionField_ScaleWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) Scroll += 5;
            if (e.Delta < 0) Scroll -= 5;
            Button_Click(sender, e);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double start = string.IsNullOrEmpty(startBar.Text) ? -1000 : double.Parse(startBar.Text);
            double end = string.IsNullOrEmpty(endBar.Text) ? 1000 : double.Parse(endBar.Text);
            double delta = string.IsNullOrEmpty(deltaBar.Text) ? 1 : double.Parse(deltaBar.Text);
            height = FunctionField.ActualHeight;
            width = FunctionField.ActualWidth;

            Function function = new Function(expressionBar.Text, start, end, delta);
            opzResult.Content = function.GetRpn();
            result.Content = function.Calculate();
            List<Value> functionValues = new List<Value>();
            functionValues = function.CalculateFunctionValues();
            valuesGrid.Items.Clear();
            AddItems(functionValues);
            DrawGraphic(functionValues);
        }


        private void FunctionField_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void AddItems(List<Value> values)
        {
            for (var i = 0; i < values.Count; i++)
            {
                valuesGrid.Items.Add(values[i]);
            }
        }

        private void DrawGraphic(List<Value> functionValues)
        {
            FunctionField.Children.Clear();           
            DrawHorizont();
            DrawVertical();

            for (int i = 0; i < functionValues.Count - 1; i++)
            {
                Line line = new Line();
                line.Stroke = Brushes.Red;
                line.StrokeThickness = 2;
                line.X1 = width / 2 + functionValues[i].X*scroll;
                line.X2 = width / 2 + functionValues[i + 1].X*scroll;
                line.Y1 = height / 2 - functionValues[i].Y*scroll;
                line.Y2 = height / 2 - functionValues[i + 1].Y*scroll;
                FunctionField.Children.Add(line);
            }
        }

        private void DrawHorizont()
        {
            Line horizontAxis = new Line();
            horizontAxis.X1 = 0;
            horizontAxis.Y1 = height / 2;
            horizontAxis.X2 = width;
            horizontAxis.Y2 = height / 2;
            horizontAxis.Stroke = Brushes.Black;
            horizontAxis.StrokeThickness = 2;

            for (int i = 0; i < width / 2; i++)
            {
                DrawCoordinatesX(i);
            }

            for (int i = 0; i > -width / 2; i--)
            {
                DrawCoordinatesX(i);
            }

            FunctionField.Children.Add(horizontAxis);
        }

        private void DrawCoordinatesX(int i)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 2;
            line.X1 = i * scroll + width / 2;
            line.X2 = i * scroll + width / 2;
            line.Y1 = (-scroll * 0.3) + height / 2;
            line.Y2 = (scroll * 0.3) + height / 2;
            FunctionField.Children.Add(line);

            TextBlock dash = new TextBlock();
            dash.Text = i.ToString();
            Canvas.SetLeft(dash, i * scroll + width / 2);
            Canvas.SetTop(dash, scroll + height / 2);
            FunctionField.Children.Add(dash);       
        }

        private void DrawVertical()
        {
            Line verticalAxis = new Line();
            verticalAxis.X1 = width / 2;
            verticalAxis.Y1 = 0;
            verticalAxis.X2 = width / 2;
            verticalAxis.Y2 = height;
            verticalAxis.Stroke = Brushes.Black;
            verticalAxis.StrokeThickness = 2;

            for (int i = 0; i < height / 2; i++)
            {
                DrawCoordinatesY(i);
            }

            for (int i = 0; i > -height / 2; i--)
            {
                DrawCoordinatesY(i);            }

            FunctionField.Children.Add(verticalAxis);
        }

        private void DrawCoordinatesY(int i)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 2;
            line.X1 = (-scroll * 0.3) + width / 2;
            line.X2 = (scroll * 0.3) + width / 2;
            line.Y1 = i * scroll + height / 2;
            line.Y2 = i * scroll + height / 2;
            FunctionField.Children.Add(line);

            TextBlock dash = new TextBlock();
            dash.Text = i.ToString();
            Canvas.SetLeft(dash, -scroll + width / 2);
            Canvas.SetTop(dash, -i * scroll + height / 2);
            FunctionField.Children.Add(dash);
        }
    }
}
