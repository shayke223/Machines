   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp1.ViewModelsWpfApp1.ViewModels  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2local clr-namespace:WpfApp1.ViewModels     5   	     � Title$  Shay Maryuma��5   	   $	��800��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ]� .+�5   
   �� $	��Top=�6   $��50��6&   
�����_�._�5      �� $��Plasson��6   $��Center=�6'   $
��Left=�6B   
�������$��16(�6p   $
��Bold"�6~   $��5q�6�   5      � 5   
   $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5#      �� $��Filter:��6   $��0��6'   $��0��64   $��Center=�6D   $��5q�6_   �� 5&       �� DisplayMemberPath$ DisplayName��5(       �� SelectedValuePath$ Value��5)      $��0��5*      $��1��6    $��5q�5+      ��5&      �� *MachineListVM.Statuses+ �� SelectedValue 5'      �� *MachineListVM.StatusFilter+5+      �� 5/       �� Orientation$ 
Horizontal=�6   $��1��62   $��2��6?   $
��Left=�6S   $��5q�6n   .+�50      �� $��Manual Refetch��6   $��0,5,5,0q�6g   ��62   �� *" MachineListVM.GetMachinesCommand+6g   �� 51      $��Add Machine Status��6   $��5,5,5,0q�6l   ��66   �� *" MachineListVM.AddMachinesCommand+6l   52      �� 56      $
��Auto=�6   $
��Auto=�6>   $��2��6c   $��2��6p   $��5q�6�   .��57      � $
��Left=�6   .+�59      �� ��6#   �� *MachineListVM.Machines+��5:      �� 5;      .R�5<   "   �� 
�������$��1q�6<    �� CornerRadius$ 8��6P   	 �� Padding$	 10q�6a   $��0,0,0,3q�6n   
�������$��Center=�6�   $	��740��6�   ._�5=   &   �� .+�5?   *   �� $ 
Horizontal=�65   .+�5@   .   �� $��Machine Name:��68   $
��Bold"�6M   $��12(�6_   
�����_�6m   �� 5A   .   $��5,0,0,0q�6U   ��68   �� *MachineName+6U   5B   +   �� 5E   *   $ 
Horizontal=�65   .+�5F   .   �� $��Description:��68   $
��Bold"�6L   $��12(�6^   �� 5G   .   $��5,0,0,0q�6U   ��68   �� *Description+6U   5H   +   �� 5K   *   $ 
Horizontal=�65   .+�5L   .   �� $��Status:��68   $
��Bold"�6G   $��12(�6Y   �� 5M   .   $��Center=�6T   $��5,0,0,0q�6o   ��68   �� *
StatusText+6o   �� 5O   .   $��12��6S   $��12��6^   $��5,0,0,0q�6j   ��64   �� *StatusImage+6j   5P   +   �� 5S   *   $ 
Horizontal=�65   .+�5T   .   �� $��Notes:��68   $
��Bold"�6F   �� 5U   .   $��12(�6O   $��5,0,0,0q�6]   ��68   �� *Notes+6]   5V   +   �� 5Y   *   $ 
Horizontal=�65   $��Right=�6N   .+�5Z   .   �� $
��Edit��65   $��0,0,0,0q�6�   ��6D   �� *.,DataContext.MachineListVM.EditMachineCommand+
 �� RelativeSource
 ��  �� AncestorType
 Window��6�   �� 6�   �� 5[   .   $��Remove��65   $��5,0,0,0q�6�   ��6F   �� *0.DataContext.MachineListVM.RemoveMachineCommand+
 �� 
 Window��6�   �� 6�   5\   +   5]   '   5^   #   5_      5a      5b      5c      5d      5e      5f      