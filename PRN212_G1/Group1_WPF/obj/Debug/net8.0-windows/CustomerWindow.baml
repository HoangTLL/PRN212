   M S B A M L   `   `   `  ����  
Group1_WPF    Group1_WPF.CustomerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Customer Dashboard��5   	   $	��600��6$   $
��1000��61   .��5      � .+�5	   
   �� .@�5      �� $��Profile��6   .��5      � $��20q�6    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      �� $��0��6!   .+�5      �� $��User Profile��6$   $��24(�68   $
��Bold"�6F   $��0,0,0,20q�6X   5      � 5      $��1��6    � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      $��* �6/    5      �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5       $
��Auto �6,   �� 5!      $
��Auto �6,   .+�5%      �� $��0��6$   $��0��61   $��Name:��6A   $��5q�6N   �� 5&      $��1��6$   $��0��61   $��Email:��6A   $��5q�6O   �� 5'      $��2��6$   $��0��61   $��Phone Number:��6A   $��5q�6V   �� 5(      $��3��6$   $��0��61   $��Date of Birth:��6A   $��5q�6W   �� 5)      $��4��6$   $��0��61   $��	Password:��6A   $��5q�6R   �� 5,      -   5         ��Name$ NameTextBox��5,   "   $��0��67   $��1��6D   $��5q�6T   �� 5-      -   5        $ EmailTextBox��5-   "   $��1��68   $��1��6E   $��5q�6U    �� 
IsReadOnly$
 True��6`   �� 5.      -   5        $ PhoneTextBox��5.   "   $��2��68   $��1��6E   $��5q�6U   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ 	DobPicker��5/   %   $��3��68   $��1��6E   $��5q�6U   G� 50      -   5         G�Name$ PasswordBox��50   &   $��4��6;   $��1��6H   $��5q�6X   �� 53      $��5��6%   $��1��62    �� Orientation$ 
Horizontal=�6B   $��5q�6[   .+�54      �� -   5         ��Name$ UpdateButton��54   %   $��Update Profile��6;   $	��100��6o   $��0,0,10,0q�6{   �� 55      -   5        $ LogoutButton��55   %   $��Logout��6;   $	��100��6g   56      57      58      59      �� 5<      $��Available Trips��6   .��5=      � $��20q�6    5>      �� 5?      $
��Auto �6(   �� 5@      $��* �6(   .+�5C      �� $��0��6!   .+�5D      �� $��Available Trips��6$   $��24(�6;   $
��Bold"�6I   $��0,0,0,20q�6[   5E      &   System.Windows.Controls.DataGrid  5G      -   5        	  Name$	 TripsDataGrid��5G      $��1��5H      
   AutoGenerateColumns$
 False��5I         
IsReadOnly$
 True��5J         GridLinesVisibility$	 All=�5K         AlternatingRowBackground
 �����   RowHeaderWidth$ 0Q�5M         Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+6T     5P      $ Pick-up Location��61   $ * 6s    6K   �� *PickUpLocation.Name+6s     5Q      $ Drop-off Location��61   $ * 6u    6L   �� *DropOffLocation.Name+6u     5R      $ Booking Date��61   $
 Auto 6g    6G   �� *BookingDate+6g     5S      $
 Time��61   $
 Auto 6]    6?   �� *	HourInDay+6]     5T      $ Min Persons��61   $
 Auto 6d    6F   �� *	MinPerson+6d     5U      $ Max Persons��61   $
 Auto 6d    6F   �� *	MaxPerson+6d   4  .System.Windows.Controls.DataGridTemplateColumn  5V      $ Actions��65   $
 Auto 6F      CellTemplate 5W   "   �� 5X   &   .R�5Y   *   �� -	   5        $
��Book��5Y   1   $��5q�5Z   1   $
��10,5q�6<   5[   '   5]      5_      5`      5a      �� 5d      $��My Bookings��6   .��5e      � $��20q�6    5f      �� 5g      $
��Auto �6(   �� 5h      $��* �6(   .+�5k      �� $��0��6!   .+�5l      �� $��My Bookings��6$   $��24(�67   $
��Bold"�6E   $��0,0,0,20q�6W   �� 5m      -
   5        $��Delete��5m   !   $	��146��62   6>   5n        5p      -   5        $	 MyBookingsDataGrid��5p      $��1��5q      $
 False��5r      $
 True��5s      $	 All=�5t      
 �����$ 0Q�5v       �� SelectedItem 5p   <   �� *SelectedBooking+ �� Mode$ TwoWay=� 5w        5x      $ 
Booking ID��61   $
 Auto 6\    6E   �� *Id+6\     5y      $ Trip ID��61   $
 Auto 6]    6B   �� *TripId+6]     5z      $ Status��61   $
 Auto 6\    6A   �� *Status+6\     5{      $ PickUpLocation��61   $
 Auto 6v    6I   �� *Trip.PickUpLocation.Name+6v     5|      $ DropOffLocation��61    6J   �� *Trip.DropOffLocation.Name+  5}      $ Booking Date��61   $
 Auto 6l    6G   �� *Trip.BookingDate+6l     5~      $
 Time��61   $
 Auto 6b    6?   �� *Trip.HourInDay+6b     5      $ Actions��65   $
 Auto 6F    5�   "   �� 5�   &   .R�5�   *   �� -   5        $��Cancel��5�   1   $��5q�6^   $
��10,5q�6i   ��5�   .   �� 5�   2    �� 
TargetType" ��68    �� Triggers 5�   6   �� 5�   :    �� Binding 6F   �� *Status+ �� Value 06a   .a�5�   >   ��  �� Property � {� �� Value$ False��6Z   5�   ;   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      