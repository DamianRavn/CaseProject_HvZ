import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

const apiURl = "https://hvzapi.azurewebsites.net/api/game";

export const fetchGames = createAsyncThunk("game/fetchGames", async () => {
  return fetch(`${apiURl}`, {
    method: "GET",
  })
    .then((response) => {
      console.log(response);
      if (!response.ok) {
        throw new Error("Could not get games");
      }
      return response.json();
    })
    .catch((error) => {
      console.log(error);
    });
});

export const gameSlice = createSlice({
  name: "games",
  initialState: {
    games: [],
    status: "idle",
  },
  reducers: {
    register: (state, action) => {
      state.games = action.payload;
    },
  },
  extraReducers: {
    [fetchGames.pending]: (state, action) => {
      state.status = "loading";
    },
    [fetchGames.fulfilled]: (state, payloadObj) => {
      console.log(payloadObj);
      state.games = payloadObj.payload;
      state.status = "success";
    },
    [fetchGames.rejected]: (state, action) => {
      state.status = "failed";
      state.error = action.error.message;
    },
  },
});

export default gameSlice.reducer;

export const selectAllGames = (state) => state.games;
