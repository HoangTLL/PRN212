   M S B A M L   `   `   `  ����E  AGroup1_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Group1_WPF
Group1_WPF  5   	       Group1_WPF.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Group1_WPF     5   	     � Title$  AdminWindow��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      � .+�5
   
   �� .@�5      �� $��Manage Trips��6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��5q�6:   .+�5      �� -   5         ��Name$ AddTripButton��5   !   $��Add Trip��68   $��5q�6K   ���	#FF4096FF���	#FF4096FF
�������$��26��6�   $��89��6�   6�   �� 5      -   5        $ EditTripButton��5   !   $��	Edit Trip��69   $��5q�6M   $��92��6X   ���	#FF4096FF���	#FF4096FF
�������6�   �� 5      -   5        $ DeleteTripButton��5   !   $��Delete Trip��6;   $��5q�6Q   $��92��6\   ���	#FF4096FF���	#FF4096FF
�������6�   5      �� 5      $��1��6   $��5q�6+    � ToolTip$ Search trips by name��5      ��5   6   �� *TripSearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5      &   System.Windows.Controls.DataGrid  5      $��2��6      AutoGenerateColumns$ False��5      ��5   ,   �� *FilteredTrips+ �� SelectedItem 6R   �� *SelectedTrip+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Id+  5      $
 Pick Up Location��61    6K   �� *PickUpLocation.Name+  5      $
 Drop Off Location��61    6L   �� *DropOffLocation.Name+  5      $
 
Max Person��61    6E   �� *	MaxPerson+  5       $
 
Min Person��61    6E   �� *	MinPerson+  5!      $
 Booking Date��61    6G   �� *BookingDate+  5"      $
 Hour In Date��61    6G   �� *	HourInDay+  5#      $
 Status��61    6A   �� *Status+5%      5&      5'      �� 5(      $��Manage Locations��6   $��20��60   $	��Top=�6<   .��5)      �  � ColumnDefinitions 5*      �� 5+      $	��21* �6+   �� 5,      $
��376* �6+    5.      �� 5/      $
��Auto �6(   �� 50      $��* �6(   �� 51      $
��Auto �6(   .+�54      �� $ 
Horizontal=�6!   $
��Left=�6:   $��0��6U   $��462,10,0,10q�6b   $��1��6w   .+�55      �� -   5         ��Name$ SearchLocationTextBox��55   "   $	��200��6A   $��Center=�6M   $ Search locations by name��57   "   ��56   "   �� *LocationSearchText+$ PropertyChanged=�57   "   �� 58      -   5        $ SearchButton��58   !   $��Search��67   $��75��6H   $��5,0,0,0q�6S   $��Center=�59   !   ��6<   �� *SearchLocationCommand+6f   5:        5;      -   5          Name$ LocationsDataGrid��5;      $��1��6:   $��10,10,10,10q�6G   $ False��5=         CanUserAddRows$ False��6:      
IsReadOnly$
 True��6Q      AlternatingRowBackground
 �����   GridLinesVisibility$ 
Horizontal=�5>   F   $��2��6g   ��5<   %   �� *FilteredLocations+	 5?        5@      $
 ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T      MinWidth$ 50Q�6a      
IsReadOnly$
 True��6o    6=   �� *Id+6o     5A      $
 Location Name��61   $ * 6a   $	 150Q�6k    6H   �� *Name+6k     5B      $
 Status��61   $	 100 6\   $ 80Q�6h    6A   �� *Status+6h   5D      �� 5G      $ 
Horizontal=�6!   $
��Left=�6:   $��2��6U   $��190,10,0,10q�6b   $��1��6w   .+�5H      �� -   5        $ AddLocationButton��5H   !   $��Add Location��6<   $��5q�6S   ���	#FF4096FF���	#FF4096FF
�������$	��100��5J   !   6-   �� 5K      -   5        $ EditLocationButton��5K   !   $��Edit Location��6=   $��5q�6U   $	��100��5L   !   ���	#FF4096FF���	#FF4096FF
�������5M   !   �� 5N      -	   5        $ DeleteLocationButton��5N   !   $��Delete Location��6?   $��5q�6Y   $	��100��5O   !   ���	#FF4096FF���	#FF4096FF
�������5P   !   5Q      5R      5S      �� 5T      $��Manage User��6   $��
-2,-2,-2,0q�6+   .��5U      � 
�������.+�5V      �  5W      �� 5X      $
��Auto �6,   �� 5Y      $
��Auto �6,   �� 5Z      $��* �6,   .+�5\      �� $ 
Horizontal=�6%   $��5q�6>   .+�5]      �� -
   5        $ AddUserButton��5]   %   $��Add User��6<   $��5q�6O   ���	#FF4096FF���	#FF4096FF
�������$��26��6�   $��89��6�   6�   �� 5^      -   5        $ EditUserButton��5^   %   $��	Edit User��6=   $��5q�6Q   $��92��6\   ���	#FF4096FF���	#FF4096FF
�������6�   �� 5_      -   5        $ DeleteUserButton��5_   %   $��Delete User��6?   $��5q�6U   $��92��6`   ���	#FF4096FF���	#FF4096FF
�������6�   5`      �� 5a      -   5        $ 
SearchUser��5a   "   $��1��67   $��5q�6D   $ Search trips by name��5b      ��5a   O   �� *UserSearchText+$ PropertyChanged=�5b        5c      -   5        $ UserDataGrid��5c   #   $��2��69   $ False��5d      ��5c   F   �� *FilteredUsers+ 6l   �� *SelectedUser+	 5e        5f   "   $
 ID��65    6A   �� *Id+  5g   "   $

 Name��65    6C   �� *Name+  5h   "   $
 Email��65    6D   �� *Email+  5i   "   $
 Phone Number��65    6K   �� *PhoneNumber+  5j   "   $
 Password��65    6G   �� *
Password+  5k   "   $
 Date Of Birth��65    6L   �� *DateOfBirth+  5l   "   $
 
Created At��65    6I   �� *	CreatedAt+  5m   "   $

 Role��65    6C   �� *Role+  5n   "   $
 Status��65    6E   �� *Status+5p      5q      5r      5s      5t      5u      5v      