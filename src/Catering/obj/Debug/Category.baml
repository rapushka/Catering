   M S B A M L   `   `   `  ����C  ?Catering, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CateringCatering  5          Catering.Category   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Catering     5        N� Title$  Category��5	       � 	Resources 5
         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 J� SnapsToDevicePixels
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6$   .�5      ��  � ��# � ��6+   �� 5       � ��$ 1q�6(   �� 5       � ��$ 1q�60   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6,   �� 5       � ��$ Center=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ Bd��6!   $ 0��6-   #��z��6>   #��z��6j   #��z��5      # z��6G   	 . ._�5      �� #��z��6/   #��z��6c   # z
 5   !   #��z��6]   #	 z	 5   !   #��z��6]   5       5      P� 5       �@J�IsMouseOver . . �5    "   �� $ Bd��6?    � ��
 �����6O   5!      P� 5"       �@J�IsKeyboardFocused . . �5#   "   �� $ Bd��6?    � ��
 �����6O   5$      P� 5%       � {� .  . �5&   "   �� # � ��6?    � ��5'      5)      5+      5,      5-      .��5/      �  � ColumnDefinitions 50   
   �� 51      $
��487* �6   �� 52      $
��493* �6    � RowDefinitions 54   
   �� 55      $��40 �6   �� 56      $��48 �6   �� 57      $��384.8 �6   �� 58      $
��84.8 �6   �� 59      $��36 �6   �� 5:      $
��73.6 �6   .+�5<   
   �� $��0��6   $��2��6   ._�5=      �� $��Center=�6   $��Center=�5>      .+�5?      �� $!��Категории блюд��6   $��Verdana)�5@      $��18(�61   5A      5B      �� 5C   
   $��1��6   $��2��6   ._�5D      ��  �� Orientation$ 
Horizontal=�6   $��Stretch=�5E      $��Stretch=�5F      .+�5G      �� $.��(searchmagnifierinterfacesymbol_79894.png��6   $��5q�5H      $��25��6#   �� 5I      $��Наименование:��6   $��Center=�5J      $��Center=�5K      $��0,0,5,0q�5L      $��14(�5M      $��Verdana)�6*   �� 5N      $��25��6   $	��788��6&   $��Verdana)�5O      $��14(�6/   $��	0,12,0,11q�5P      �� 5Q      $.��(searchmagnifierinterfacesymbol_79894.png��6   $��5q�5R      $��25��6#   5S      5T      �� 5U   
   $��2��6   $��2��6   $��	0,0,0,0.8q�62   ._�5V      �� $��Stretch=�6   $��Stretch=�5W      .+�5X      &   System.Windows.Controls.DataGrid  $	��382��6   5Y      5Z      �� 5[   
   $��3��6   $��5,9.2,5,5.6q�6   $��2��63   ._�5\      �� $ 
Horizontal=�6   $	��Top=�5]      $��Center=�5^      $��2,0,1,0q�5_      $	��977��5`      .+�5a      �� $��Добавить��6   $��Verdana)�5b      $��16(�5c      $��71��5d      #���   5e      $	��338��5f      �� 5g      $ ��Редактировать��6   $��Verdana)�5h      $��16(�5i      $��71��5j      #���   5k      $	��320��5l      �� 5m      $��Удалить��6   $��Verdana)�5n      $��16(�5o      $��71��5p      #���   5q      $	��320��5r      5s      5t      �� 5u   
   $��4��6   $��0��6   $��5,5.4,5.2,5.2q�6.   $��2��6E   ._�5v      �� $��Stretch=�6   $	��Top=�5w      $ 
Horizontal=�5x      .+�5y      �� $��Наименование:��6   $��Verdana)�5z      $��14(�61   $��24��6?   $��	0,0,0.2,0q�6K   5|      �� 5}      $��Verdana)�6   $��14(�60   $��26��6>   $��	0,0,0.2,0q�6J   $	��318��6]   5~      5      �� 5�   
   $��5��6   $��0,1.4,0,0.2q�6   $��2��63   ._�5�      �� $ 
Horizontal=�6   .+�5�      �� $��Добавить��6   $��Verdana)�5�      $��16(�5�      $��40��5�      #���   5�      $	��327��5�      $	��5,4q�5�      5�      �� 5�      $+��%Применить изменения��6   $��Verdana)�5�      $��16(�5�      $��40��5�      #���   5�      $	��5,4q�5�      $	��311��6&   �� 5�      $��Отменить��6   $��Verdana)�5�      $��16(�5�      $��40��5�      #���   5�      $	��312��5�      $	��5,4q�5�      5�      5�      5�      5�      5�      