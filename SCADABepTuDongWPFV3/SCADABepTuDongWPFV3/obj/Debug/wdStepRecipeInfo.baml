   M S B A M L   `   `   `  ����N  JSCADABepTuDongWPFV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SCADABepTuDongWPFV3SCADABepTuDongWPFV3  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5	   	   *    $SCADABepTuDongWPFV3.wdStepRecipeInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SCADABepTuDongWPFV3     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5	   	      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   
���   �$��Medium"�5   	   $��14(�5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 	Add Water��5   	   $	��297��6   $	��327��6(   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        	ParamHour  ParamMin  ParamSec  ParamCloseLid �� Type  ParamOpenLid  ParamAddBox��%  &	       &	 4     &	 �     &	 �    &	 X    &	     ��5   
    0,1,2,3,4,5,6,7,8,9,10,11,12��6J   ��5   
   ��0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59��6�   ��5   
   ��0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59��6�   �� 5   
   " ��6(   .s�5      ��Đóng xong đảo nhanh��6.   ��5      Đóng xong đảo chậm��6-   ��5      Đóng xong đảo vừa��6,   ��5      Đóng xong không đảo��6.   ��5      )%Đóng xong đảo xoay chiều nhanh��69   ��5      *&Đóng xong đảo xoay chiều chậm��68   ��5       )%Đóng xong đảo xoay chiều vừa��67   5!      �� 5"   
   " ��6'   .s�5#      ��Mở hé một nửa��6(   ��5$      Mở tốc độ chậm��6)   ��5%      ($Mở chế độ chống bắn dính��63   5&      �� 5'   
   " ��6&   .s�5(      ��Đổ nhanh��6#   ��5)      Đổ chậm��6"   ��5*      Đổ vào xong lắc��6*   ��5+      Lắc xong đổ vào��6*   5,      5-      .��5.      �  � RowDefinitions 5/   
   �� 50      $
��auto �6   6,   �� 51      6   �� 52      $
��auto �6   6,   .+�54   
   � $��0��6   $��5q�6   .+�55      �� -   5        $
��auto��55      $
��Left=�6"   $��40��6=   
������ 
������  � Cursor$
 Hand��6|   .��56      ��  �� Orientation$ 
Horizontal=�6   .+�57      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 	ArrowLeft=�6.   
���   �$��Center=�6R   �� 58      -   5        
 ��Name$
 lbTitle��58      $	��...��6-   $��18(�6;   6K   59      5:      �� 5;      $��Bottom=�6   $��
10 10 10 0q�63   6I   5<      � 5=   
   $��1��6   $��0 0 0 0q�6   .+�5>      #  MaterialDesignThemes.Wpf.Card  $��	10 5 10 5q�6"   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�65   .��5?      �  5@      �� 5A      $
��auto �6(   68   �� 5B      $
��auto �6(   68   �� 5C      $
��auto �6(   68   .+�5E      � $��0��6   .+�5F      �� $ Vertical=�6%   .+�5G      �� -   5         ��Name$ cbParamCloseLid��5G   >   $y�	Collapsed=�6'   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 	Parameter��6W   $��72��5H   '   $��
15 10 15 0q�65    �� SelectedIndex$ 0��5I   '    & "MaterialDesignFloatingHintComboBox#��[ 69   �� 5J      -   5        $ cbParamOpenLid��5J   >   $y�	Collapsed=�6'   $ 	Parameter��6V   $��72��5K   '   $��
15 10 15 0q�65   $ 0��5L   '   #��[ 69   �� 5M      -   5        $ cbParamAddBox��5M   >   $y�	Collapsed=�6'   $ 	Parameter��6U   $��72��5N   '   $��
15 10 15 0q�65   $ 0��5O   '   #��[ 69   �� 5P      -   5         ��Name$ txtParam��5P   &   $��0��68   $ Parameter (ml)��6A    %	 !MaterialDesignFloatingHintTextBox#��[	 5Q   &   $��40��6a   $	��Top=�6m   $��
15 15 15 0q�5R   &   5S      5T      � 5U      -   5         �Name$ GridTemp��5U   (   $��1��6   $y�Visible=�6:    � ColumnDefinitions 5V      �� 5W      $	��70* �6/   �� 5X      $
��237* �6/   .+�5Z      �� -   5        $ 
txtNhietDo��5Z   "   $��0��66   $ Temperature (°C)��6?   #��[	 5[   "   $��40��6]   $	��Top=�6i   $��
15 15 15 0q�5\   "   $��2��66   5]      � 5^      -	   5        $ GridTime��5^   (   $��2��6   $y�Visible=�6:    5_      �� 5`      61   �� 5a      61   �� 5b      61   .+�5d      � $��0��6   .+�5e      �� -
   5        $ cbHour��5e   '   $
 Hour��67   $��72��5f      $��
15 10 15 0q�6)   #��[ 5g      $ 0��5h      #��[ 5i      5j      � 5k      $��1��6   .+�5l      �� -   5        $ cbMinute��5l   '   $ Minute��69   $��72��5m      $��
15 10 15 0q�6)   #��[ 5n      $ 0��5o      #��[ 5p      5q      � 5r      $��2��6   .+�5s      �� -   5        $ cbSecond��5s   '   $ Second��69   $��72��5t      $��
15 10 15 0q�6)   #��[ 5u      $ 0��5v      #��[ 5w      5x      5y      5z      5{      5|      � 5}   
   $��2��6   $��10 20 10 10q�6   .+�5~      �� -   5        $��OK��5~      68   5      5�      5�      