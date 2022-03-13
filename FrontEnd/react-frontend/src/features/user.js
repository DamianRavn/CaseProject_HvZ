import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
  name: "user",
  initialState: { value: { id: -1, first_name: "", last_name: "" } },
  reducers: {
    register: (state, action) => {
      state.value = action.payload;
    },
  },
});

export default userSlice.reducers;
