mergeInto(LibraryManager.library, {
  CallReactLink: function (type, link) {
    window.dispatchReactUnityEvent(
      "CallReactLink",
      Pointer_stringify(type),
Pointer_stringify(link)
    );
  },
});