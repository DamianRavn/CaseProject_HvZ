import "./App.css";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import keycloak from "./keycloak";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <ReactKeycloakProvider authClient={keycloak}>
        <h1 className="text-3xl font-bold underline">
          Hello world with Tailwind!
        </h1>
      </ReactKeycloakProvider>
    </div>
  );
}

export default App;
