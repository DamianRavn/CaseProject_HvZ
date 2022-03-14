import { configureStore } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import userSlice from "./features/userSlice";

const store = configureStore({
  reducer: {
    users: userSlice,
  },
});

setupListeners(store.dispatch);

export default store;
