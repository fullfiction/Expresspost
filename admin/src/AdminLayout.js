import React from "react";
import { Layout } from "react-admin";
import AdminAppbar from "./AdminAppbar";
import AdminMenu from "./AdminMenu";

const AdminLayout = (props) => (
	<Layout {...props} appBar={AdminAppbar} menu={AdminMenu} />
);

export default AdminLayout;
