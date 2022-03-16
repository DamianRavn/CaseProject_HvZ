import Keycloak from "keycloak-js";

const keycloak = new Keycloak({
  url: "http://localhost:8080/",
  realm: "dev",
  clientId: "HvZ",
});

export default keycloak;
