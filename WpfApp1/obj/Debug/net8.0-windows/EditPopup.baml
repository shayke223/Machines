   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.EditPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   ��5   	   $	��400��6   $	��300��6    � WindowStartupLocation$ CenterScreen=�5      .��5      � $��Center=�6   $��Center=�6(   $	��200��6C   $	��394��6R   $	��364��6b   .+�5   
   ��  �� Orientation$ Vertical=�6   $
��Left=�6,   $��
10,25,10,0q�6G   $	��260��6[   .+�5
      �� $��Machine Name:��6   $
��Bold"�6-   
�����_�6?   �� 5      $��0��5      $��1��6   $��0,10,0,0q�5      ��5      �� *MachineNames+ �� SelectedValue 5      �� *MachineName+5      �� 5      $��Description:��6   $
��Bold"�6,   $��0,10,0,0q�6>   �� 5      $��0,10,0,0q�63   ��6   �� *Description+63   �� 5      $��Status:��6   $
��Bold"�6'   $��0,10,0,0q�69   �� 5       �� DisplayMemberPath$ DisplayName��5       �� SelectedValuePath$ Value��5      $��0,10,0,0q�5      ��5      �� *
Statuses+ 5      �� *Status+5      �� 5"      $��Notes:��6   $
��Bold"�6&   $��0,10,0,0q�68   �� 5#      $��0,10,0,0q�6-   $	��100��6?   $��Stretch=�6L    �� TextWrapping$
 Wrap=�5$   
    �� AcceptsReturn$
 True��6   " �� VerticalScrollBarVisibility$
 Auto=�63   ��5#      �� *Notes+5$   3   �� 5(      $ 
Horizontal=�6   $��Right=�62   $��0,10,0,0q�6N   .+�5)      �� $��Cancel��6   $��75��6*   ��65   �� *CancelCommand+��6W   �� 	 �� RelativeSource	 �� 
 �� AncestorType

 Window�� 5*      $
��Save��6   $��75��6(   $��5,0,0,0q�6�   ��63   �� *SaveCommand+��6S   �� 	 �� 

 Window6�   5+      5-      5.      5/      