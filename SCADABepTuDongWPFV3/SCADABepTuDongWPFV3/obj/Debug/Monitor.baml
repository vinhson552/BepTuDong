   M S B A M L   `   `   `  ����N  JSCADABepTuDongWPFV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SCADABepTuDongWPFV3SCADABepTuDongWPFV3  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters 5   	   E'clr-namespace:SCADABepTuDongWPFV3.ModelSCADABepTuDongWPFV3.Model  5	   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
   	   eHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	   !    SCADABepTuDongWPFV3.Monitor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SCADABepTuDongWPFV3     5   	   xmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   5domain1'clr-namespace:SCADABepTuDongWPFV3.Model  5	   	   0sys&clr-namespace:System;assembly=mscorlib  5
   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5   	   -   5        $��wSendRTU��5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	     � WindowStyle$
  None=�5   	    � Title$ Overview Recipe��5   	   $��700         ��6!   $	��400��5       � WindowStartupLocation$ CenterScreen=�6   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      � $��0,0,0,-7q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5    
   � $��0��6   $��0q�6   .+�5!      (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$ PrimaryDark=�5!   '   $��16q�6:   $��55��6G   .��5"      �  � ColumnDefinitions 5#      �� 5$      $
��auto �6+   6:   �� 5%      6-   .+�5'      � $��0��6   .+�5(      �� -   5        $��16(�5(   !   $��50��6/   
�������$��Center=�5)      $
��Left=�68     MaterialDesignFlatButton#��[ 5*       � ToolTip$
 Back��6O   .��5+      ��  �� Orientation$ 
Horizontal=�6)   .+�5,   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6:   $��25��6K   $��25��6W   $��Center=�6b   �� 5-   "   -   5        	 ��Name$	 lbTitle��5-   (   $
��BACK��69   
�������$��40��6[   $��Center=�6h   6�   5.      5/      50      51      52      54      � 55   
   $��1��6   .+�59      �� -   5        $
��Cook��59      $��145,8,177,297q�6$   $��70��6;   $��32��6F   $
��Bold"�6R     MaterialDesignRaisedButton#���  5:   )   +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth3=�5;   )    J� RenderTransformOrigin$ -1.143,0.937&�6Z   5<      � 5=   
   $��2��6    5>      �� 5?      $	��45* �6#   �� 5@      $	��11* �6#   .+�5B      �� $��Cook 1:��6   $
��Left=�6&   $��18,-287,0,0q�6A   $	��Top=�6V   $��18(�6n   �� 5C      -   5         ��Name$ txtReceiveMessage1��5C      $
��Left=�62   $��25,-262,0,0q�6M   $	��Top=�6c   $	��270��6{   $��30��6�   $��18(�6�   $ 0.5,0.5&�6�   6�   5D      � 5E   
   $��3��6   .+�5F      �� $��Cook 2:��6   $
��Left=�6&   $��15,-227,0,0q�6A   $	��Top=�6V   $��18(�6n   �� 5G      -   5        $ txtReceiveMessage2��5G      $
��Left=�62   $��25,-202,0,0q�6M   $	��Top=�6c   $	��270��6{   $��30��6�   $��18(�6�   $ 0.5,0.5&�6�   6�   5H      � 5I   
   $��4��6   .+�5J      �� $��Cook 3:��6   $
��Left=�6&   $��15,-167,0,0q�6A   $	��Top=�6V   $��18(�6n   �� 5K      -   5        $ txtReceiveMessage3��5K      $
��Left=�62   $��20,-142,0,112q�6M   $	��270��6d   $��18(�6p   $ 0.5,0.5&�6~   5L      � 5M   
   $��5��6   $��0,2,7,7q�6   .+�5N      �� $��Cook 4:��6   $
��Left=�6&   $��15,-108,0,0q�6A   $	��Top=�6V   $��18(�6n   �� 5O      -	   5        $ txtReceiveMessage4��5O      $
��Left=�62   $��20,-78,0,347q�6M   $	��270��6c   $��18(�6o   $ 0.5,0.5&�6}   5P      5Q      5R      