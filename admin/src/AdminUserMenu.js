import React from "react";
import { UserMenu, MenuItemLink } from "react-admin";
import SettingsIcon from "@material-ui/icons/Settings";
import jwt from "jwt-decode";

const AdminUserMenu = (props) => {
	var token = localStorage.getItem("token");
	var claims = token == null ? {} : jwt(token);
	return (
		<UserMenu {...props}>
			<MenuItemLink
				to={"/Admins/" + claims.id}
				primaryText={claims.username}
				leftIcon={<SettingsIcon />}
			/>
		</UserMenu>
	);
};

export default AdminUserMenu;
