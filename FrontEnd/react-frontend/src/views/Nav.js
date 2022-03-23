import React from "react";
import KeycloakService from "../services/KeycloakService";
import UserPlaceHolderImg from "../images/UserPlaceHolderImg.png";
import HvZLogo from "../images/HvZLogo.png";

const Nav = () => {
  const handleLoginClick = () => {
		KeycloakService.doLogin();
	}
  const handleLogoutClick = () => {
		KeycloakService.doLogout();
	}

  return (
    <nav class="bg-white border-gray-200 px-2 sm:px-4 py-2.5 rounded dark:bg-gray-800">
      <div class="container flex flex-wrap justify-between items-center mx-auto">
        <a href="/" class="flex items-center">
          <img src={HvZLogo} class="mr-3 h-6 sm:h-9" alt="HvZ Logo" />
          <span class="self-center text-xl font-semibold whitespace-nowrap dark:text-white dark:focus:ring-blue-800">
            Humans Vs. Zombies
          </span>
        </a>
        <div className="flex md:order-2 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 rounded-2xl">
          <img
            class="object-scale-down scale-75"
            src={UserPlaceHolderImg}
            alt=""
          />
          {!KeycloakService.isLoggedIn() && (
            <button
              type="button"
              onClick={handleLoginClick}
              class="text-white  font-medium text-sm px-5 py-2.5 flex"
            >
              Login
            </button>
          )}
          {KeycloakService.isLoggedIn() && (
            <button
              type="button"
              onClick={handleLogoutClick}
              class="text-white  font-medium text-sm px-5 py-2.5 flex"
            >
              Logout ({KeycloakService.getUsername()})
            </button>
          )}
        </div>
        <div
          class="hidden justify-between items-center w-full md:flex md:w-auto md:order-1"
          id="mobile-menu-4"
        >
          <ul class="flex flex-col mt-4 md:flex-row md:space-x-8 md:mt-0 md:text-sm md:font-medium"></ul>
        </div>
      </div>
    </nav>
  );
};

export default Nav;
