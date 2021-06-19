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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double start = string.IsNullOrEmpty(startBar.Text) ? -1000 : double.Parse(startBar.Text);
            double end = string.IsNullOrEmpty(endBar.Text) ? 1000 : double.Parse(endBar.Text);
            double delta = string.IsNullOrEmpty(deltaBar.Text) ? 1 : double.Parse(deltaBar.Text);

            Function function = new Function(expressionBar.Text, start, end, delta);

            opzResult.Content = function.GetRpn();
            result.Content = function.Calculate();

            List<Value> functionValues = new List<Value>();
            functionValues = function.CalculateFunctionValues();

            valuesGrid.Items.Clear();
            AddItems(functionValues);

            DrawGraphic(functionValues);
            //FunctionField.Children.Clear();
            //Line xAxis = new Line();
            //double height = FunctionField.ActualHeight;
            //double width = FunctionField.ActualWidth;

            //xAxis.X1 = 0;
            //xAxis.Y1 = height / 2;
            //xAxis.X2 = width;
            //xAxis.Y2 = height / 2;
            //xAxis.Stroke = Brushes.Red;
            //xAxis.StrokeThickness = 2;
            //FunctionField.Children.Add(xAxis);
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

        //private void Draw()
        //{
        //    FunctionField.Children.Clear();
        //    double height = FunctionField.ActualHeight;
        //    double width = FunctionField.ActualWidth;

        //    var xAxis = DrawGorizont(height, width);
        //    var yAxis = DrawVertikal(height, width);

        //    //Polygon arrow1 = new Polygon();
        //    //arrow1.Points.Add(new Point(height / 2, width));
        //    //arrow1.Points.Add(new Point(height / 2 - 10, width - 15));
        //    //arrow1.Points.Add(new Point(height / 2 + 10, width - 15));
        //    //arrow1.Fill = Brushes.Black;

        //    Point pointStart = new Point(width / 2 + 40, height / 2 + 40);
        //    Point pointEnd = new Point(width / 2 + 40, height / 2 + 40);

        //    //Ellipse elipse = new Ellipse();
        //    //elipse.Width = 4;
        //    //elipse.Height = 4;
        //    //elipse.StrokeThickness = 2;
        //    //elipse.Stroke = Brushes.Red;
        //    //elipse.Margin = new Thickness(point.X - 2, point.Y - 2, 0, 0);


        //    FunctionField.Children.Add(xAxis);
        //    FunctionField.Children.Add(yAxis);
        //    //canvasPlot.Children.Add(arrow1);
        //    //canvasPlot.Children.Add(elipse);
        //    PathGeometry geo = new PathGeometry();
        //    PathFigure function = new PathFigure();
        //    function.StartPoint = pointStart;
        //    LineSegment line = new LineSegment(pointEnd, false);
        //    function.Segments.Add(line);
        //    function.Segments.Add(new LineSegment(function.StartPoint, false));
        //    geo.Figures.Add(function);
        //    FunctionField.Children.Add(new Path { Stroke = Brushes.Red, StrokeThickness = 3, Data = geo });
        //

        private void DrawGraphic(List<Value> functionValues)
        {
            FunctionField.Children.Clear();
            double height = FunctionField.ActualHeight;
            double width = FunctionField.ActualWidth;
            DrawGorizont(height, width);
            DrawVertikal(height, width);
            for (int i = 0; i < functionValues.Count - 1; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = Brushes.Red;
                myLine.StrokeThickness = 2;
                myLine.X1 = width / 2 + functionValues[i].X;
                myLine.X2 = width / 2 + functionValues[i + 1].X;
                myLine.Y1 = height / 2 - functionValues[i].Y;
                myLine.Y2 = height / 2 - functionValues[i + 1].Y;
                FunctionField.Children.Add(myLine);
            }
        }

        private void DrawGorizont(double height, double width)
        {
            Line xAxis = new Line();

            xAxis.X1 = 0;
            xAxis.Y1 = height / 2;
            xAxis.X2 = width;
            xAxis.Y2 = height / 2;
            xAxis.Stroke = Brushes.Black;
            xAxis.StrokeThickness = 2;

            FunctionField.Children.Add(xAxis);
        }

        private void DrawVertikal(double height, double width)
        {
            Line yAxis = new Line();

            yAxis.X1 = width / 2;
            yAxis.Y1 = 0;
            yAxis.X2 = width / 2;
            yAxis.Y2 = height;
            yAxis.Stroke = Brushes.Black;
            yAxis.StrokeThickness = 2;

            FunctionField.Children.Add(yAxis);
        }
    }

    class Item
    {
        public double X { get; set; }

        public double Y { get; set; }
    }
}
