echo "Running Raspberry-Pi Test Program ..."
if ip a | grep -q eth0 ; then echo "Ethernet: detected" ; else echo "Ethernet" ; fi;
if ip a | grep -q wlan0 ; then echo "Wi-Fi: detected" ; else echo "Wi-Fi" ; fi;
if hciconfig | grep -q "hci0" ; then echo "Bluetooth: detected"; else "Bluetooth" ; fi;
if lsusb -t | grep -q "Driver=dwc2/1p" ; then echo "USB-OTG: detected" ; else "USB-OTG" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/4p" ; then echo "USB 3: detected" ; else "USB 3" ; fi;
if lsusb -t | grep -q "Driver=xhci_hcd/1p" ; then echo "USB C: detected" ; else "USB C" ; fi;
if lsusb -t | grep -q "Driver=hub/4p" || lsusb -t | grep -q "Driver=hub/5p" ; then echo "USB 2: detected" ; else "USB 2" ; fi;