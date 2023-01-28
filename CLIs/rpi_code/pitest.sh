#copy this script and create pitest.sh in your pitest home directory
echo ">>>>>>>> Pi testing program <<<<<<<<"
if ip a | grep -q eth0 ; then echo "ethernet: found" ; else echo "ethernet" ; fi;
if ip a | grep -q wlan0 ; then echo "wifi: found" ; else echo "wifi" ; fi;
if hciconfig | grep -q "hci0" ; then echo "bluetooth: found"; else "bluetooth" ; fi;
if lsusb -t | grep -q "Driver=dwc2/1p" ; then echo "usb-otg: found" ; else "usb-otg" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/4p" ; then echo "usb 3: found" ; else "usb 3" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/1p" ; then echo "usb c: found" ; else "usb c" ; fi;
if lsusb -t | grep -q "Driver=hub/4p" || lsusb -t | grep -q "Driver=hub/5p" ; then echo "usb 2: found" ; else "usb 2" ; fi;