import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

const apiURl = "https://hvzapi.azurewebsites.net/api/Users";

export const fetchUsers = createAsyncThunk("user/fetchUser", async () => {
  return fetch(`${apiURl}`, {
    method: "GET",
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
    users: [],
    status: "idle",
  },
  reducers: {
    register: (state, action) => {
      state.users = action.payload;
    },
  },
  extraReducers: {
    [fetchUsers.pending]: (state, action) => {
      state.status = "loading";
    },
    [fetchUsers.fulfilled]: (state, payloadObj) => {
      console.log(payloadObj);
      state.users = payloadObj.payload;
      state.status = "success";
    },
    [fetchUsers.rejected]: (state, action) => {
      state.status = "failed";
      state.error = action.error.message;
    },
  },
});

export default userSlice.reducer;

export const selectAllUsers = (state) => state.users;
