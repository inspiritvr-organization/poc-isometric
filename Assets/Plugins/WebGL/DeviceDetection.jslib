var DeviceDetection = {
    IsMobile: function()
    {
        return Module.SystemInfo.mobile;
    }
};
 
mergeInto(LibraryManager.library, DeviceDetection);