import React from "react";
import { AppBar } from "react-admin";
import AdminUserMenu from "./AdminUserMenu";

const AdminAppBar = (props) => (
	<AppBar {...props} userMenu={<AdminUserMenu />} />
);
export default AdminAppBar;
