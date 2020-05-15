import React from "react";
import PostIcon from "@material-ui/icons/Book";
import UserIcon from "@material-ui/icons/Group";
import {
	fetchUtils,
	Admin,
	Resource,
	ListGuesser,
	EditGuesser,
} from "react-admin";
import jsonServerProvider from "ra-data-json-server";
import Dashboard from "./Dashboard/Dashboard";
import authProvider from "./Security/authProvider";
import { AdminsList, AdminsEdit, AdminsCreate } from "./Admins/Admins";

const httpClient = (url, options = {}) => {
	if (!options.headers) {
		options.headers = new Headers({ Accept: "application/json" });
	}
	const token = localStorage.getItem("token");
	options.headers.set("Authorization", `Bearer ${token}`);
	return fetchUtils.fetchJson(url, options).then(({ headers, json }) => {
		if (!json.succeed) throw new Error(json.error);
		return { headers: headers, json: json.data };
	});
};
const dataProvider = jsonServerProvider(
	"http://localhost:5000/api/v1",
	httpClient
);

const App = () => (
	<Admin
		dashboard={Dashboard}
		authProvider={authProvider}
		dataProvider={dataProvider}
	>
		{/* <Resource
			name="posts"
			list={PostList}
			edit={PostEdit}
			create={PostCreate}
			icon={PostIcon}
		/>
		<Resource name="users" list={UserList} icon={UserIcon} /> */}
		<Resource
			name="Admins"
			list={AdminsList}
			edit={AdminsEdit}
			create={AdminsCreate}
			icon={UserIcon}
		/>
	</Admin>
);

export default App;
