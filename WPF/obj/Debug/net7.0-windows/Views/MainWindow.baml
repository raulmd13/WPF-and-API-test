   M S B A M L   `   `   `  ����F  BMecalux WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Mecalux_WPFMecalux_WPF  5   	       Mecalux_WPF.MainWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   A =Wpf.Ui, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5   	   %localclr-namespace:Mecalux_WPF  5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��949��6)    � 
ResizeMode$ NoResize=�5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��61* �6   �� 5      $	��39* �6   .+�5   
   �� -   5         ��Name$ cmbOrderOptions��5      $
��auto��6�   $��Right=�6�   $	��Top=�6�   $��Center=�6	  $��	0,75,10,0q�6.  $��1��6A  ��6,   �� *orderOptions+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6v   �� *SelectedOrderOption+$ PropertyChanged=�6A    Wpf.Ui.Controls.Button  5   
   -   5        $��RefreshOrderButton��5      $��Refresh order options��6/   $��	0,34,10,0q�6~   $	��Top=�6�   $��Right=�6�   $
��auto��6�   $��1��6�    J� RenderTransformOrigin$ 0.508,0.464&�6�   ��6O   �� *RefreshOrderOptionsCommand+6�     Wpf.Ui.Controls.TextBox  5   
   $��95,79,220,0q�6   $	��Top=�6G   $
��auto��6_   $��2��6m   ��6*   �� *TextToOrder+6m     5   
   $��95,242,220,0q�6   $	��Top=�6H   $
��auto��6`    �� 
IsReadOnly$
 True��6n   $��2��6�   ��6+   �� *OrderedText+6�   �� 5   
   $��Text to order:��6   $
��Left=�6)   $��	10,75,0,0q�6D   $	��Top=�6W   $ 0.038,-0.037&�6o   �� 5   
   $��Ordered text:��6   $
��Left=�6(   $��
10,238,0,0q�6C   $	��Top=�6W   $ 0.038,-0.037&�6o     5   
   $��
Order text��6   $��	10,34,0,0q�6O   $	��Top=�6b   $
��auto��6z   ��6*   �� *OrderTextCommand+6z     5   
   $��Calculate statistics��6   $��
122,34,0,0q�6b   $
��auto��6v   $	��Top=�6�   $ -0.076,-0.148&�6�   ��63   �� *CalculateStatisticsCommand+6�   �� 5   
   $��Text statistics��6   $��155,143,10,0q�6,   $��1��6B   $	��209��6R   $	��Top=�6_   .��5      �� $
��auto��6   .+�5      ��  �� ContentStringFormat$ Hyphens Number: {0}��6p   $ 
5.1,23.704&�6�   ��6   �� * TextStatistics.hyphensQuantity+$ PropertyChanged=�6�   �� 5      $ Words number: {0}��6m   $ 	7.3,9.104&�6�   ��6   �� *TextStatistics.wordQuantity+$ PropertyChanged=�6�   �� 5      $ Spaces number: {0}��6o   ��6   �� *TextStatistics.spacesQuantity+$ PropertyChanged=�6o   5      5      5#      5$      