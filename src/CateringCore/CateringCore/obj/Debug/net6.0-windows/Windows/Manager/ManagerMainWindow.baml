   M S B A M L   `   `   `  ����  CateringCore,    &CateringCore.Windows.ManagerMainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          � Title$  Менеджер��5   	   $	��750��6   $
��1200��6'    � WindowStartupLocation$ CenterScreen=�5   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��192.8 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��52 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,9,9.8,-5.2q�5      $��1��6+   .+�5      �� -   5        $��
Заказ��5      $��Verdana)�5      $��16(�5      $	��120��5      $��2q�5      $��Stretch=�5         ButtonStyle#���   5      $
��Bold"�5      5      �� 5      -   5        $��Сотрудники��5      $��Verdana)�5      $��16(�5       $	��120��5!      $��2q�5"      $��Stretch=�5#      #���   5$      $
��Bold"�5%      5&      �� 5'      -   5        $��
Блюда��5'      $��Verdana)�5(      $��16(�5)      $	��120��5*      $��2q�5+      $��Stretch=�5,      #���   5-      $
��Bold"�5.      5/      �� 50      -   5        $��Посуда��50      $��Verdana)�51      $��16(�52      $	��120��53      $��2q�54      $��Stretch=�55      #���   56      $
��Bold"�57      58      �� 59      -   5        $��Автомобиль��59      $��Verdana)�5:      $��16(�5;      $	��120��5<      $��	2,2,2.2,2q�5=      $��Stretch=�5>      #���   5?      $
��Bold"�5@      5A      5B      �� 5C   
   $��0��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5D      .+�5E      ��  
 Avatar#���  6   $��31��5F      $��5q�5G      �� 5H      -   5        $��EmployeeFullnameTextBlock��5I      $4��.[ФИО сотрудникa], Менеджер��5J      $��Verdana)�5K      $��39��6&   $��0,0,843.8,0q�62   5L      � 5M   
   $��1��6   $��1��6   ��5N      �� 5O       �� ImageSource$$ ../../Resources/Background.jpg��5P       j� TileMode$ FlipXY=�5Q      .+�5S       � -   5        $��Frame��5S      
���   �$��Stretch=�5U      $��Stretch=�5V        � NavigationUIVisibility$ Hidden=�5W      5X      5Z      5[      