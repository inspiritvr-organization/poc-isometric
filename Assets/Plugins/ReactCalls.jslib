mergeInto(LibraryManager.library, {
  SendReactData: function (type) {
    window.dispatchReactUnityEvent(
      "SendReactData",type
    );
  },
});