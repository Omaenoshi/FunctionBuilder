   M S B A M L   `   `   `  ����R  NFunctionBuilder.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:OPZ.DesktopOPZ.Desktop  5   	       OPZ.Desktop.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:OPZ.Desktop     5   	     � Title$  
MainWindow��5   	   $	��562��6   $	��627��6)   .��5	      � $��0,0,-1,2q�6    J� RenderTransformOrigin$ 0.563,0.744&�6   .+�5
   
   �� -   5        $��Посчитать��5
      $
��Left=�6%   $��
229,28,0,0q�6@   $	��Top=�6T   $��19��6l   $��99��6x   6�   �� 5   
   -   5         ��Name$ expressionBar��5      $
��Left=�6)   $��	51,29,0,0q�6D   $�� ��6W    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��167��6�   $��18��6�   6�   �� 5   
   -   5         ��Name$ OpzResultBar��5      $
��Left=�6*   $��
364,30,0,0q�6E   $
��Wrap=�6Y   $	��Top=�6m   $��52��6�   $��ОПЗ =��6�   �� 5   
   -   5         ��Name$ result��5      $�� ��6   $
��Left=�6+   $��	76,89,0,0q�6F   $	��Top=�6Y   $��27��6q   $��78��6}   �� 5   
   -   5        $ OpzBar��5      $
��Left=�6$   $��	34,94,0,0q�6?   $
��Wrap=�6R   $	��Top=�6f   $��50��6~   $��
ОТВЕТ��6�   �� 5   
   -   5        $ 	opzResult��5      $�� ��6#   $
��Left=�6.   $��
400,26,0,0q�6I   $	��Top=�6]   $	��167��6u   $��24��6�   �� 5   
   -   5        $ OpzResultBar_Copy��5      $
��Left=�6/   $��	25,10,0,0q�6J   $
��Wrap=�6]   $	��Top=�6q   $	��103��6�   $��18��6�   �� 6�    � Language$ ru-ru�6�   $#�Введите функцию��6�   6�   �� 5   
   -   5        $ OpzResultBar_Copy1��5      $
��Left=�60   $��	27,31,0,0q�6K   $
��Wrap=�6^   $	��Top=�6r   $��24��6�   $��y=��6�   �� 5   
   -	   5        $ OpzBar_Copy��5      $
��Left=�6)   $��	25,65,0,0q�6D   $
��Wrap=�6W   $	��Top=�6k   $��91��6�   �� 6�   $ ru-ru�6�   $!�Введите начало��6�   6�   �� 5   
   -
   5        $ startBar��5      $
��Left=�6$   $��
122,66,0,0q�6?   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $��24��6�   $��18��6�   6�   �� 5   
   -   5        $ OpzBar_Copy1��5      $
��Left=�6*   $��
208,65,0,0q�6E   $
��Wrap=�6Y   $	��Top=�6m   $��91��6�   �� 6�   $ ru-ru�6�   $�Введите конец��6�   6�   �� 5   
   -   5        $ endBar��5      $
��Left=�6"   $��
304,65,0,0q�6=   $�� ��6Q   $
 Wrap=�6Y   $	��Top=�6m   $��24��6�   $��18��6�   6�   �� 5   
   -   5        $ deltaBarText��5      $
��Left=�6*   $��
381,67,0,0q�6E   $
��Wrap=�6Y   $	��Top=�6m   $	��169��6�   �� 6�   $�Введите ��6�   �� 6�   $ ru-ru�6�   $)�#величину изменения��6�   6�   �� 5   
   -   5        $ deltaBar��5      $
��Left=�6$   $��
555,67,0,0q�6?   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $��24��6�   $��18��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
valuesGrid��5      $��0��6'   $��10,121,511,0q�67      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 X��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 10 6G      MinWidth$ 20Q�6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *X+6R     5      $	 Y��6%   $
 10 6G   $ 20Q�6R    60   �� *Y+6R   5      �� 5   
   -   5        $��FunctionField��5      $��122,121,10,10q�6&   
�������$
}�True��6}   5      5       