   M S B A M L   `   `   `  ����@  <Test1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Test1.ViewModelsTest1.ViewModels  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   )clr-namespace:Test1.ViewsTest1.Views  5   7       Test1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Test1.ViewModels     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   (vwclr-namespace:Test1.Views     5   7     �Language$  pl-PL� � Title$ 
MainWindow��6	   $
��1566��6   $
��1100��6*    � 	Resources 5       �� DataType(   "Test1.ViewModels.CustomerViewModel   Test1.Views.NewCustomer.   (Test1.ViewModels.CustomerViewModelSecond$   Test1.Views.AddNewCustomerView+  %Test1.ViewModels.OrderViewModelSecond    Test1.Views.OrdersListView%  Test1.ViewModels.OrderViewModel   Test1.Views.OrderView'	   !Test1.ViewModels.ProductViewModel"
   Test1.Views.ProductsListView#   Test1.ViewModels.UserControl1   Test1.Views.SummaryView(  "Test1.ViewModels.SupplierViewModel   Test1.Views.SupplierView$  Test1.ViewModels.CostViewModel   Test1.Views.CostView   IconButton1 �� 
TargetType �� Property �� Value �� ImageSource �� 
TargetType	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName  IconButton2  IconButton3  IconButton4  Leftbuttons��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5"      *, +)(�� �     5%      *,	 +)(�� �     5)      *, +)(�� ,    5-      *, +)(�� ^    50      *, +)&	  �    &	     &	 �    &	 	    &	 �    �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5         5!      �� 5"   
   "  6   .R�5#        5$      �� 5%   
   " 	 6   .R�5&      
  5'      �� 5)   
   "  6   .R�5*        5+      �� 5-   
   "  6   .R�5.        5/      �� 50   
   "  6   .R�51        52      �� 55   
   " ��6$   .�57      ��  � �� �#0006+   �� 58       � �� 59      �� 5:      $E ?C:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon1.jpg��6!   5<      �� 5=       � �� 5>      �� 5?      " ��6&   .R�5@      �� $	 imageBorder��6!   #��z��66   ._�5A      �� #��z��6/   $��Center=�6S   $��Center=�6p   5B      
 5C      P� 5D       �@J�IsMouseOver . . �5E   "   �� $ imageBorder��6?    � �� 5F   &   �� 5G   *   $I CC:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon1over.jpg��65   5I   #   5J      5L      5N      5O      �� 5Q   
   " ��6$   .�5S      ��  � �� �#0006+   �� 5T       � �� 5U      �� 5V      $E ?C:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon2.jpg��6!   5X      �� 5Y       � �� 5Z      �� 5[      " ��6&   .R�5\      �� $	 imageBorder��6!   #��z��66   ._�5]      �� #��z��6/   $��Center=�6S   $��Center=�6p   5^      
 5_      P� 5`       �@J�IsMouseOver . . �5a   "   �� $ imageBorder��6?    � �� 5b   &   �� 5c   *   $I CC:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon2over.jpg��65   5e   #   5f      5h      5j      5k      �� 5m   
   " ��6$   .�5p      ��  � �� �#0006+   �� 5q       � �� 5r      �� 5s      $E ?C:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon5.jpg��6!   5u      �� 5v       � �� 5w      �� 5x      " ��6&   .R�5y      �� $	 imageBorder��6!   #��z��66   ._�5z      �� #��z��6/   $��Center=�6S   $��Center=�6p   5{      
 5|      P� 5}       �@J�IsMouseOver . . �5~   "   �� $ imageBorder��6?    � �� 5   &   �� 5�   *   $I CC:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon5over.jpg��65   5�   #   5�      5�      5�      5�      �� 5�   
   " ��6$   .�5�      ��  � �� �#0006+   �� 5�       � �� 5�      �� 5�      $E ?C:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon4.jpg��6!   5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $	 imageBorder��6!   #��z��66   ._�5�      �� #��z��6/   $��Center=�6S   $��Center=�6p   5�      
 5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ imageBorder��6?    � �� 5�   &   �� 5�   *   $I CC:\Users\48570\source\repos\Test1\Test1\Assets\poprawaIcon4over.jpg��65   5�   #   5�      5�      5�      5�      �� 5�   
   " ��6$   .�5�      ��  � �� �#0006+   �� 5�       � �� 5�      �� 5�      $ buttonleftgrey.jpg��6!   5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $	 imageBorder��6!   #��z��66   ._�5�      �� #��z��6/   $��Center=�6S   $��Center=�6p   5�      
 5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ imageBorder��6?    � �� 5�   &   �� 5�   *   $F @C:\Users\48570\source\repos\Test1\Test1\Assets\buttonleftred.jpg��65   5�   #   5�      5�      5�      5�      5�      .��5�      �� .��5�   
   �  � ColumnDefinitions 5�   
   �� 5�      $	��120 �6   �� 5�       � RowDefinitions 5�   
   �� 5�      $��80 �6   �� 5�      �� 5�      .+�5�   
   �� �� 5�   
   -   5         ��Name$ 
navigation��5�      $��1��6)   $��0��69   $��2��6F    �� Orientation$ 
Horizontal=�6Z   .+�5�      �� $ 
Horizontal=�6   .+�5�      �� #��[  6   $	��109��6>   $��24��6J   $��	25 0 25 0q�6V   ��6i   �� *UserControl1ViewCommand+�� 5�      #��[ 6   $��93��6>   $��20��6I   $��	25 0 25 0q�6U   ��6h   �� *OrdersListViewCommand+�� 5�      #��[ 6   $��80��6>   $��22��6I   $��	25 0 25 0q�6U   ��6h   �� *ProductViewCommand+�� 5�      #��[ 6   $��62��6>   $��20��6I   $��	25 0 25 0q�6U   ��6h   �� *NewCustomerCommand+�� 5�      #��[ 6   $��62��6>   $��20��6I   $��	25 0 25 0q�6U   ��6h   �� *SupplierViewCommand+�� 5�      #��[ 6   $��62��6B   $��20��6M   $��	25 0 25 0q�6Y   ��6l   �� *CostViewCommand+5�      5�      �� 5�   
   -   5         ��Name$ Pages��5�      $��1��6(   $��1��68   $��2��6E   $
��Left=�6V   $	��Top=�6q   $
��1000��6�   $
��1500��6�   $��0 50 0 0q�6�   ��6�   �� *SelectedViewModel+6�   �� 5�   
   ���#81d8b8$
��Left=�6#   $��56��6>   $��
103,10,0,0q�6J   $	��Top=�6^   $��2��6v   �� 5�   
   $
��Left=�6   $��39��6+   $	��Top=�67   $��73��6O   $��	10,20,0,0q�6Z   $��logo.jpg��6m   $
��Fill=�6    �� StretchDirection$ DownOnly=�6�   �� 5�   
   ���#ff86a5$
��Left=�6#   $��56��6>   $��
105,10,0,0q�6J   $	��Top=�6^   $��2��6v   �� 5�   
   $
��Left=�6   $��0,39,0,0q�6,   $��1��6>   $	��Top=�6K   $	��105��6c   $��99��6o   #��[ 6{   ��6�   �� *OrderViewCommand+.��5�      �� $��13(�6   $
��Bold"�6&   ���#fff$
��Wrap=�6J   $��Dodaj zamówienie��6^   $��80��6v   $��37��6�   5�      �� 5�   
   $
��Left=�6   $��	0,138,0,0q�6,   $��1��6?   $	��Top=�6L   $	��105��6d   $��99��6p   #��[ 6|   ��6�   �� *ProductViewCommand+��5�      �� 5�      $ buttonleftgrey.jpg��6   .��5�      �� $��13(�6   $
��Bold"�6&   ���#fff$
��Wrap=�6J   $��Dodaj produkt��6^   $��80��6s   $��37��6~   5�      �� 5�   
   $
��Left=�6   $��	0,237,0,0q�6,   $��1��6?   $	��Top=�6L   $	��105��6d   $��99��6p   #��[ 6|   ��6�   �� *AddNewCustomerViewCommand+��5�      �� 5�      $ buttonleftgrey.jpg��6   .��5�      �� $��13(�6   $
��Bold"�6&   ���#fff$
��Wrap=�6J   $��Dodaj klienta��6^   $��80��6s   $��37��6~   5�      �� 5�   
   ���#81d8b8$��2��6#   $��3��6.   $��Stretch=�6B   $��0,71,0,6q�6`   �� 5�   
   ���#ff86a5$��2��6#   $��3��6.   $��Stretch=�6B   $��0,74,0,4q�6`   5�      .  (System.Windows.Interactivity.Interaction   Triggers 5     /  )System.Windows.Interactivity.EventTrigger  5  
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5     6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *UserControl1ViewCommand+5     5     5     