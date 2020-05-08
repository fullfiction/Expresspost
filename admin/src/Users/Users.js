import React from "react";
import { List, Datagrid, TextField, EmailField, UrlField } from "react-admin";
import CustomUrlField from "../Components/CustomUrlField";

export const UserList = (props) => (
	<List {...props}>
		<Datagrid rowClick="edit">
			<TextField source="id" />
			<TextField source="name" />
			<EmailField source="email" />
			<TextField source="phone" />
			<UrlField source="website" />
			<CustomUrlField source="website" />
			<TextField source="company.name" />
		</Datagrid>
	</List>
);
