   M S B A M L   `   `   `  ����  GamblingPlatform    GamblingPlatform.DLT   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$	  DLT��5   	   $	��300��6   $	��300��6"    � 	Resources 5         alternatingWithTriggers �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��60   .�5      ��  � ��
 ��  �6+   �� 5       � ��
 �����6+    5	      P� 5
       �@��AlternationIndex$ 1��6>   . �5      ��  � ��
 ��d�63   �� 5       � ��
 �   �63   5      P� 5       �@��AlternationIndex$ 2��6>   . �5      ��  � ��
 ��ح�63   �� 5       � ��
 ��  �63   5      5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
myDataGrid��5         AutoGenerateColumns .  	   CanUserAddRows	 . 
 �� AlternationCount$
 3��5      #��[  6)   ��5      �� *
PersonList+ 5      *  $System.Windows.Controls.DataGridCell��%d   '        �� 5      "  6   .�5      ��  �@�ToolTip 6:   �� *Error+5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 期数��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5    %   ��  �� Path$ 	FirstName� �� ValidatesOnDataErrors .   5!      $ 1��6%   $ * 60    5"   %   �� $ LastName� .   5#      $ 2��6%   $ * 60    5$   %   �� $ 	FirstName� .   5%      $ 3��6%   $ * 60    5&   %   �� $ LastName� .   5'      $ 4��6%   $ * 60    5(   %   �� $ 	FirstName� .   5)      $ 5��6%   $ * 60    5*   %   �� $ LastName� .   5+      $ 1��6%   $ * 60    5,   %   �� $ 	FirstName� .   5-      $ 2��6%   $ * 60    5.   %   �� $ LastName� . 4  .System.Windows.Controls.DataGridCheckBoxColumn  5/      $ Job Flag��6)   $ * 6w    6;   �� $ HasJob� . 6w     50      $ 
Job's Name��6%   $ * 6v    69   �� $ JobName� . 6v   52      53      54      