   M S B A M L   `   `   `  ����M  IBusinessCardWizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BusinessCardWizard.WindowsBusinessCardWizard.Windows  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel 6@   I)clr-namespace:BusinessCardWizard.ControlsBusinessCardWizard.Controls  6�   &     BusinessCardWizard.Windows.Shell   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:BusinessCardWizard.Windows     5   	   SComponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase     6@   8uc)clr-namespace:BusinessCardWizard.Controls     6�     � 
ResizeMode$  NoResize=�5   	    � Title$$ Windows Business Card Wizard®��5	   	   $	��935��6/   $	��935��6<   #��["��6H    � 	Resources 5       
  sorted �� Source �� SortDescriptions+  %System.ComponentModel.SortDescription   PropertyName��%k   &	        �� 5   
    6.   �� *
contacts+ 5        5      $ LastName��61   5      5      .��5      ]� .+�5   
   +   %BusinessCardWizard.Controls.SearchBar  $	��Top=�6   �� 5   
   $��Bottom=�6   $��30 0 0 2q�6-   .+�5      �� .@�5      �� $��Right=�6    .��5      �� -   5         ��Name$ 
zoomslider��5      $	��125��61    � Value$ 1Q�6=    � Minimum$ .5Q�6G   	 � Maximum$	 2Q�6T   5      �� 5      $��Right=�6    .��5      �� Zoom:6'   5       �� 5!      $
��Left=�6    .��5"      �� $��Demibold"�6   .��62   	Status:6;   5#      �� 5$      $
��Left=�6    .��5%      �� -   5        
 ��Name$
 status��5%       5&      5'      5(      9� 5*   
   $
��Left=�6    9� ExpandDirection$ Right=�6)    9� 
IsExpanded . $��0q�6S   
�������$��5 0 0 0q�6z   ��5+      �� 5,      $��16(�6   
Contacts � LayoutTransform 5-      �� 5.       �� Angle$ 90Q�6*   50      .��52      )   #BusinessCardWizard.Controls.SideBar  -   5          Name$ sidebar��52      )   #BusinessCardWizard.Controls.SideBar   click$ RoutedEvent��6*   6>   53      �� 55   
   -   5         ��Name$
 tabs��55      
������ $��5 3 10 5q�6<    56      �� 57       �� ScaleX 6!   ��  �� ElementName$ 
zoomslider�� �� Path$ Value� �� ScaleY 58   !   �� $ 
zoomslider��$ Value�5:      5;      5<      