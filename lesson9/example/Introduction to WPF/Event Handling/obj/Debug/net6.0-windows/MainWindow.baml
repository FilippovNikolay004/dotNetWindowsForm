   M S B A M L   `   `   `  ����  2. Event Handling    Event_Handling.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Window1��5   	   $	��300��6   $	��300��6&   .��5      � -   5        $��grid1��5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   $��43��6*   �� 5	      $��* �6   ��5   
   �� 5      ��5      �  � Offset$
 0.00Q�6#    � Color$	 Red��62   � 5      $
 0.50Q�6#   $ Indigo��61   � 5      $
 1.00Q�6#   $ Violet��61   5      .+�5   
   �� -   5        $
��txt1��5   a   $��Stretch=�6   $��Stretch=�6.   $��10,10,13,10q�6L   $��Verdana)�5      $��24(�6#   $��0��61    �� AcceptsReturn$
 True��6>    �� 
AcceptsTab$
 True��6S   .��6e   [Enter a text]5      �� 5   
   -   5        $��	cmdAnswer��5   H   $	��Top=�6   $��	10,0,13,0q�6)   $��23��6<   $��1��5      .��6   
Click me5      �� 5   
   2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve5   U   -   5        $
��txt2��5   a   $��Stretch=�6   $��Stretch=�6.   $��10,10,13,10q�6L    �� 
IsReadOnly$
 True��5      $��Verdana)�6   $��24(�64   
��� � �$��2��6U   .��6b           
        5      5      5       