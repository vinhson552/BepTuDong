   M S B A M L   `   `   `  ����N  JSCADABepTuDongWPFV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SCADABepTuDongWPFV3SCADABepTuDongWPFV3  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5	   	   *    $SCADABepTuDongWPFV3.wdEditIngredient   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SCADABepTuDongWPFV3     5   	   FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5	   	      MaterialDesignBody#���   5
   	     MaterialDesignPaper#���  5   	   $��Medium"�5   	   $��14(�5   	     � WindowStyle$
  None=�5   	    � Title$ wdEditIngredient��5   	   $	��155��6"   $	��400��6/    � WindowStartupLocation$ CenterScreen=�6;   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��45 �6   6*   �� 5      6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  $��0��6#      Mode$ PrimaryDark=�60   $��12q�6C   $��40��6P   .��5      �  � ColumnDefinitions 5      �� 5      $
��auto �6'   66   �� 5      6)   .+�5      � $��0��6   .+�5      �� -   5         ��Name$ btnBack��5      $��12(�6.   $��50��6<   
�������$��Center=�5       $
��Left=�68     MaterialDesignFlatButton#��[ 5!       � ToolTip$
 Back��6O   .��5"      ��  �� Orientation$ 
Horizontal=�6%   .+�5#      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 	ArrowLeft=�66   $��25��6G   $��25��6S   $��Center=�6^   �� 5$      -   5        
 ��Name$
 lbTitle��5$   $   $��Edit Ingredient��65   
�������$��40��6b   $��Center=�6n   6�   5%      5&      5'      � 5(      $��1��6   .+�5)      �� -   5        $ btnSave��5)   Y   $
��SAVE��6   $��12(�6,   $��50��6:   
�������$��Center=�5*      $��Right=�68   $��Center=�6T   $��Center=�6v   #��[ 5+      $ Save the Ingredient��6O   5,      5-      5.      � 5/   
   $��1��6   $��
20 5 20 10q�6    50      �� 51      6%   �� 52      6%   .+�54      �� $��0��6   $	��150��6)   $��Bottom=�65   $
��Left=�6P   .+�55      �� -   5        $
 lbIngredient��55      $
��Bold"�6.   $��Ingredient Name:��6@   $��Bottom=�6[   6x   56      �� 57      $��1��6   $	��150��6)   $��Bottom=�65   $��Right=�6P   .+�58      �� -   5        $
 lbUnit��58      $��Unit:��6(   $
��Bold"�68   $��Bottom=�6J   6g   59      5:      � 5;   
   $��2��6   $��20 10 20 10q�6    5<      �� 5=      6%   �� 5>      6%   .+�5@      �� $��0��6   $	��150��6)   $
��Left=�65   $	��Top=�6P   .+�5A      �� -   5        $��txtIngreName��5A       % !MaterialDesignFloatingHintTextBox#��[ 6.   6k   5B      �� 5C      $��1��6   $	��150��6)   $��Right=�65   $	��Top=�6Q   .+�5D      �� -   5         ��Name$ cbUnit��5D       �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6_   ��6>   �� *
ListUnit+6�   5E      5F      5G      5H      