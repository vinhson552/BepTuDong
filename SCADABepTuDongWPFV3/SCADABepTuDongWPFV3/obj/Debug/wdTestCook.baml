   M S B A M L   `   `   `  ����N  JSCADABepTuDongWPFV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SCADABepTuDongWPFV3SCADABepTuDongWPFV3  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962a{Sclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf#MaterialDesignThemes.Wpf.Converters 5   	   E'clr-namespace:SCADABepTuDongWPFV3.ModelSCADABepTuDongWPFV3.Model  5
   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   eHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5   	   $    SCADABepTuDongWPFV3.wdTestCook   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SCADABepTuDongWPFV3     5   	   xmaterialDesignConvertersSclr-namespace:MaterialDesignThemes.Wpf.Converters;assembly=MaterialDesignThemes.Wpf     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   5domain1'clr-namespace:SCADABepTuDongWPFV3.Model  5
   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5   	   -   5        $��
wdActivate��5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	     � WindowStyle$
  None=�5   	    � Title$ 
wdTestCook��5   	   $	��750��6   $	��620��6)    � WindowStartupLocation$ CenterScreen=�65   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��50 �6   6*   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   $��0q�6   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$ PrimaryDark=�5   '   $��13q�6:   $��55��6G   .��5      �  � ColumnDefinitions 5       �� 5!      $
��auto �6+   6:   �� 5"      6-   .+�5$      � $��0��6   .+�5%      �� -   5        $��16(�5%   !   $��50��6/   
�������$	��Top=�5&      $��Center=�65     MaterialDesignFlatButton#��[ 5'       � ToolTip$
 Back��6O   $��	0,-14,0,0q�6^   .��5(      ��  �� Orientation$ 
Horizontal=�6)   .+�5)   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�6:   $��25��6K   $��25��6W   $��Center=�6b   �� 5*   "   -   5        	 ��Name$	 lbTitle��5*   (   $��Activate��69   
�������$��40��6_   $��Center=�6l   6�   5+      5,      5/      �� 50      -   5        $��1��50      $��Button��6-   $
��Left=�6>   $��
374,-7,0,0q�6Y   $	��Top=�6m   $��39��6�   $��84��6�   ���	#FFC33AED6�   53      54      55      � 56   
   $��3��6   .+�57      �� -   5        
 ��Name$
 lvRecipeList��57       �� SelectedItem 58      �� *SelectedItem+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� View 59      �� 5:      .P�5;      ��  �� Width$ 90��6)   $
��Step��6Y    �� DisplayMemberBinding 64   �� *STT+6Y   �� 5<      $	 200��6)   $��Name activate��6b    65   �� *DisplayName+6b   �� 5=      $	 110��6)   $��Param��6\    65   �� *Param+6\   �� 5>      $	 100��6)   $
��Temp��6[    65   �� *Temp+6[   �� 5?      $	 100��6)   $��Timer��6\    65   �� *Timer+6\   5A      5C      5E      � 5F   
   $��2��6   .+�5G      �� -   5        $��Hienthi1��5G      $��30(�6&   .��65   5I      5K      � 5L   
   $��4��6   .+�5M      �� -   5        $��Hienthi2��5M      .��6'   5O      5Q      5S      5T      