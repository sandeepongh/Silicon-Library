#copy this script and create pitest.sh in your pitest home directory
echo "Running Raspberry-Pi Test Program ..."
if ip a | grep -q eth0 ; then echo "Ethernet: found" ; else echo "Ethernet" ; fi;
if ip a | grep -q wlan0 ; then echo "Wi-Fi: found" ; else echo "Wi-Fi" ; fi;
if hciconfig | grep -q "hci0" ; then echo "Bluetooth: found"; else "Bluetooth" ; fi;
if lsusb -t | grep -q "Driver=dwc2/1p" ; then echo "USB-OTG: found" ; else "USB-OTG" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/4p" ; then echo "USB 3: found" ; else "USB 3" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/1p" ; then echo "USB C: found" ; else "USB C" ; fi;
if lsusb -t | grep -q "Driver=hub/4p" || lsusb -t | grep -q "Driver=hub/5p" ; then echo "USB 2: found" ; else "USB 2" ; fi;