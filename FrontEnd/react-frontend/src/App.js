import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <div className="App">
          <h1 className="text-3xl font-bold underline">
            Hello world with Tailwind!
          </h1>
        </div>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
