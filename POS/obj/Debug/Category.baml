   M S B A M L   `   `   `  ����>  :POS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:POSPOS  5          POS.Category   5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:POS     5      .��5
      � -   5        $	��cat��5
   !   $��0,0,-31,-218q�6   .+�5   
   �   � RowDefinitions  5      �� 5      $��50 �6    6.   �� 5      $��40 �6    6.   �� 5      $��* �6    6-   .+�5      � $��0��6   ���	#FF1778DA$��1��67   $��40��6H   $	��Top=�6V   $��	 0,0,31,0q�6n   .+�5      �� -   5        $��5q�5      ���	#FF79A6CD$
��Left=�6;   
�������$	��145��6k   .��5      � $	��150��6    � ColumnDefinitions 5      �� 5      $��2* �6/   �� 5      $��3* �6/   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardBackspace=�62   $��Center =�6K    J� RenderTransformOrigin$ 1.281,0.531&�6g   $	��8,0q�6�   6�   �� 5      $��15(�6%   $��2��64   $
��26,0q�6H   $��20��6V   $	��Top=�6b   �� 6{   $�Back To List��6   .�6�   ��5      �� 5   "   .�5   .   5      6!   5      5      5       � 5!      $��1��6   .+�5"      �� $��Add Category��6   $��Center=�61   $
��Left=�6L   $��20(�6g   $��5 0 0 0q�6u   6�   5#      5%      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ 	datagrid1��5(   !   $��2��6   	datagrid1��   SelectionMode$ Single=�6F   $��0,200,31,214q�6^      AutoGenerateColumns .  $��2��6�   ��6t   ��    Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6D   -   5        
CategoryId��	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 Auto 5*   v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
CategoryId+6�     5+      $
 Name��6F   -   5        CategoryName��$

 Auto 5+   j    6%   �� *CategoryName+6y   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $
 Edit��6)      CellTemplate 5-      �� 5.      .R�5/      �� -   5        $
��Edit��5/   %   ��6K   �� *id+6m   50      52        53      $ delete��6)    54      �� 55      .R�56      �� -   5        $��Delete��56   %   6P   57      59      5;      �� 5<   
   -   5        $��txtCategoryName��5<   �   $��2��6   $��Center=�6&   $��23��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6c   $	��120��6{   $��100,125,50,0q�6�   6�   �� 5=   
   $��2��6   $��Name:��6$   $��Center=�64   $��
0,100,50,0q�6Q   $	��Top=�6e    �� Target 6~   ��  �� ElementName$ txtCategoryName���� 5>   
   -	   5         ��Name$ 	btnsubmit��5>      $��2��6$   $��Submit��68   $��Center=�6I   $	��Top=�6f   $��77��6~   $��
60,160,0,0q�6�   6�   �� 5?   
   $��2��6   $��Cancel��6%   $��Center=�66   $	��Top=�6S   $��75��6k   $��230,160,0,0q�6v   5@      5A      