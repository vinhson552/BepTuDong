   M S B A M L   `   `   `  ����N  JSCADABepTuDongWPFV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SCADABepTuDongWPFV3SCADABepTuDongWPFV3  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5	   	   &     SCADABepTuDongWPFV3.wdIngredient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SCADABepTuDongWPFV3     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5	   	   -   5        $��wIngredient��5   	      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	     � WindowStyle$
  None=�5   	    � Title$ Setting Ingredient��5   	   $	��650��6$   $	��550��61    � WindowStartupLocation$ CenterScreen=�6=   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��0��5   #      Mode$ PrimaryDark=�60   $��16q�6C   $��55��6P   .��5      �  � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      6)   .+�5      � $��0��6   .+�5      �� -   5        $��16(�5      $��50��6+   
�������$��Center=�5       $
��Left=�68     MaterialDesignFlatButton#��[ 5!       � ToolTip$
 Back��6O   .��5"      ��  �� Orientation$ 
Horizontal=�6%   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�66   $��25��6G   $��25��6S   $��Center=�6^   �� 5$      -   5        	 ��Name$	 lbTitle��5$   $   $��Setting Ingredient��65   
�������$��40��6e   $��Center=�6q   6�   5%      5&      5'      � 5(      $��1��6   5)      5*      5+      � 5,   
   $��1��6   .+�5-      #  MaterialDesignThemes.Wpf.Card  $��10q�6"   .��5.      �  5/      �� 50      $
��auto �6(   68   �� 51      $
��auto �6(   68   �� 52      6*   .+�54      � $��0��6   $��20 10 20 10q�6(    55      �� 56      61   �� 57      61   .+�59      �� $��0��6%   $	��150��65   $
��Left=�6A   .+�5:      �� -   5        $��txtDisplayName��5:   u   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Name Ingredient��5;   "    % !MaterialDesignFloatingHintTextBox#��[ 5<   "   ��5:   &   �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5<   _   5=      �� 5>      $��1��6%   $	��150��65   $��Right=�6A   .+�5?      �� -   5         ��Name$ cbUnit��5?   '    �� 
IsEditable .  $
 	Name Unit��6l    & "MaterialDesignFloatingHintComboBox#��[ 6�   ��6K   �� *
ListUnit+6�   5@      5A      � 5B      $��1��6   $��20 10 20 10q�6(   .+�5C      �  � Orientation$ 
Horizontal=�6$   .+�5D      �� -   5        $��Add new��5D   %   $��5 5 5 5q�67   $	��100��6H     MaterialDesignRaisedButton#���  5E   %   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5F   %   �� 5G      -   5        $
��Edit��5G   %   $��5 5 5 5q�64   $	��100��6E   #���  5H   %   $ Depth3=�5I   %   �� 5J      -	   5        $��Delete��5J   %   $��5 5 5 5q�66   $	��100��6G   #���  5K   %   $ Depth3=�5L   %   5M      5N      � 5O      $��2��6   $��10q�6(   .+�5P      �� $
��Auto=�6'   .��5Q      �� -
   5         ��Name$ lvIngredient��5R      $��10q�5Q   y   ��6'   �� *	MyList1+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 5R   '   �� *SelectedItem+$ PropertyChanged=�$ TwoWay=� �� View 5T   "   �� 5U   &   .P�5W   *   ��  �� Width$	 280��69   $��
Ingredient��6E    �� DisplayMemberBinding 6Y   �� *DisplayName+6�   �� 5X   *   $
��Unit��69   $	 120��6G    6S   �� *Unit+6{   5Y   '   5[      5\      5]      5^      5_      5`      5a      5b      