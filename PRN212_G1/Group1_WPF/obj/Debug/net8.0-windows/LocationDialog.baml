   M S B A M L   `   `   `  ����E  AGroup1_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Group1_WPF
Group1_WPF  5   	       Group1_WPF.LocationDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Group1_WPF     5   	   -   5          � Title$  LocationDialog��5   	   $	��300��6    $	��350��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0,0,0,10q�69   .+�5      �� $��Location Name:��6   �� 5      -   5         ��Name$ NameTextBox��5      $	��300��6+   ��5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5   
   $ Vertical=�6   $��1��6,   $��	0,10,0,10q�69   .+�5      �� $��Status:��6   �� 5      -   5         ��Name$ StatusComboBox��5      $	��300��6/    �� SelectedValuePath$	 Tag��5       �� SelectedValue 5      �� *Status+$ PropertyChanged=�.@�5      �� $��Active��6   
	 � Tag$	 1��60   �� 5      $��Inactive��6   $	 2��62   5      5       �� 5#   
   $ 
Horizontal=�6   $��Right=�6.   $��2��6J   $��0,10,0,0q�6W   .+�5$      �� -   5        $��OK��5$      $��75��6"   $��5q�6-   
 �� 	IsDefault$

 True��68   6I   �� 5%      -   5        $��Cancel��5%      $��75��6&   $��5q�61    �� IsCancel$
 True��6<   6L   5&      5'      5(      