   M S B A M L   `   `   `  ����J  FService portaal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Service_portaalService_portaal  5   	       Service_portaal.newvm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Service_portaal     5   	     � Title$   Virtuele machine aanvragen��5   	   $	��450��6,   $	��800��69   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��48* �6   �� 5      $
��371* �6   .+�5   
   �� -   5         ��Name$ 
aanvragbtn��5      $��Indienen��6%   $
��Left=�68   $��412,318,0,0q�6S   $	��Top=�6h   $��75��6�   $��1��6�   �� 5   
   -   5         ��Name$ 
aanvraagtb��5      $
��Left=�6&   $	��109��6A   $��
82,178,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $+��%Vul hier uw reden voor de aanvraag in��6v   $	��Top=�6�   $	��405��6�   $��1��6�    �� 
AcceptsTab .  �� AcceptsReturn . 6�   �� 5   
   $��Operating System:��6   $
��Left=�6,   $��	82,44,0,0q�6G   $	��Top=�6Z   $��2��6r   �� 5   
   -   5        $ vmnaamtb��5      $
��Left=�6$   $��23��6?   $��
228,27,0,0q�6K   $
 Wrap=�6_   $	��Top=�6s   $	��120��6�   $��1��6�   �� 5   
   $��VM naam:��6   $
��Left=�6#   $��
228,44,0,0q�6>   $	��Top=�6R   $��2��6j   �� 5   
   $��VM locatie:��6   $
��Left=�6&   $��
364,44,0,0q�6A   $	��Top=�6U   $��2��6m   �� 5   
   $��Aantal CPU cores:��6   $
��Left=�6,   $��	82,67,0,0q�6G   $	��Top=�6Z   $��1��6r   �� 5   
   $��	RAM(GB): ��6   $
��Left=�6$   $��
228,67,0,0q�6?   $	��Top=�6S   $��1��6k   �� 5   
   -   5         ��Name$ vmlocb��5      $
��Left=�6#   $��
364,28,0,0q�6>   $��1��6R   $	��Top=�6_   $	��120��6w   �� 5   
   -   5        $
 oscb��5      $
��Left=�6!   $��	82,28,0,0q�6<   $��1��6O   $	��Top=�6\   $	��120��6t   �� 5   
   -   5        $ niccb��5      $
��Left=�6"   $��
364,99,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��120��6v   �� 5   
   $
��NIC:��6   $
��Left=�6   $��
364,68,0,0q�6:   $	��Top=�6N   $��1��6f   �� 5   
   -   5        $ cpucb��5      $
��Left=�6"   $��	82,99,0,0q�6=   $��1��6P   $	��Top=�6]   $	��120��6u   �� 5   
   -   5        $ ramcb��5      $
��Left=�6"   $��
228,99,0,0q�6=   $��1��6Q   $	��Top=�6^   $	��120��6v   5      5      