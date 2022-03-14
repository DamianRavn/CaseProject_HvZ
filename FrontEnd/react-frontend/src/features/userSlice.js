import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

const apiURl = "https://localhost:44389/api/Users";

const initialStateValue = {
  users: [],
  status: "idle",
};

export const fetchUsers = createAsyncThunk("user/fetchUser", async () => {
  return fetch(`${apiURl}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((response) => {
      console.log(response);
      if (!response.ok) {
        throw new Error("Could not get users");
      }
      return response.json();
    })
    .catch((error) => {
      console.log(error);
    });
});

export const userSlice = createSlice({
  name: "users",
  initialState: {
    value: initialStateValue,
  },
  reducers: {
    register: (state, action) => {
      state.value = action.payload;
    },
  },
  extraReducers: {
    [fetchUsers.pending]: (state, action) => {
      state.value.status = "loading";
    },
    [fetchUsers.fulfilled]: (state, payloadObj) => {
      console.log(payloadObj);
      state.value = payloadObj.payload;
      state.value.status = "success";
    },
    [fetchUsers.rejected]: (state, action) => {
      state.value.status = "failed";
      state.value.error = action.error.message;
    },
  },
});

export default userSlice.reducer;

export const selectAllUsers = (state) => state.users;
