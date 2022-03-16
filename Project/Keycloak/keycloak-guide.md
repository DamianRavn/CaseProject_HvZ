# How to set up a key cloak development server

1. Make sure you have Docker installed.

2. Execute the following command in a terminal:

    `docker run --name hvz-keycloak -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:17.0.0 start-dev`

3. Go to `localhost:8080/admin` and enter "admin" as both username and password.

4. Go to "create realm" and click "import".

5. Choose the `realm-export.json` file, located in this folder.

This should set up a keycloak server with a realm called "dev" and a client called "HvZ". Realm and client name should match those in the `keycloak.js` file.