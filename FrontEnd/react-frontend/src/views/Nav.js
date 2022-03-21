import KeycloakService from "../services/KeycloakService"

const Nav = () => {
  const handleLoginClick = () => {
		KeycloakService.doLogin()
	}
  const handleLogoutClick = () => {
		KeycloakService.doLogout()
	}

  return (
    <div>
      <div className="top-0 w-full flex flex-wrap">
        <section className="x-auto">
          <nav className="flex justify-between bg-gray-200 text-blue-800 w-screen">
            <div className="px-5 xl:px-12 py-6 flex w-full items-center">
              <h1 className="text-3xl font-bold font-heading">
                Humans vs. Zombies
              </h1>
              <ul className="hidden md:flex px-4 mx-auto font-semibold font-heading space-x-12">
                <li>
                  <a className="hover:text-blue-800" href="/">
                    Home
                  </a>
                </li>
                <li>
                  <a className="hover:text-blue-800" href="/game">
                    Game
                  </a>
                </li>
              </ul>
              <div className="hidden xl:flex items-center space-x-5">
                <div className="hover:text-gray-200">
                  {!KeycloakService.isLoggedIn() && (
                    <button
                      type="button"
                      className="text-blue-800"
                      onClick={handleLoginClick}
                    >
                      Login
                    </button>
                  )}
                  {KeycloakService.isLoggedIn() && (
                    <button
                      type="button"
                      className="text-blue-800"
                      onClick={handleLogoutClick}
                    >
                      Logout ({KeycloakService.getUsername()})
                    </button>
                  )}
                </div>
              </div>
            </div>
          </nav>
        </section>
      </div>
    </div>
  );
};

export default Nav;
