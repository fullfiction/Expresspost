import React from "react";
import UserIcon from "@material-ui/icons/Group";
import { fetchUtils, Admin, Resource, ListGuesser, EditGuesser } from "react-admin";
import jsonServerProvider from "ra-data-json-server";
import Dashboard from "./Dashboard/Dashboard";
import authProvider from "./Security/authProvider";
import AdminLayout from "./AdminLayout";
import IdleTimer from "react-idle-timer";

import { EmployeesList, EmployeeEdit, EmployeeCreate } from "./Employees";
import { CompaniesList, CompanyEdit, CompanyCreate } from "./Companies";
import { CountriesList, CountryEdit, CountryCreate } from "./Countries";
import { BranchesList, BranchEdit, BranchCreate } from "./Branches";
import { LocalizationsList, LocalizationEdit } from "./Localizations"

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

const dataProvider = jsonServerProvider("http://localhost:5000/api/v1", httpClient);

const App = (props) => {
	var idleTimer = null;
	const onAction = _onAction.bind(this);
	const onActive = _onActive.bind(this);
	const onIdle = _onIdle.bind(this);

	return (
		<div>
			<IdleTimer
				ref={(ref) => {
					idleTimer = ref;
				}}
				element={document}
				onActive={onActive}
				onIdle={onIdle}
				onAction={onAction}
				debounce={250}
				timeout={60000}
			/>
			<Admin dashboard={Dashboard} authProvider={authProvider} dataProvider={dataProvider} appLayout={AdminLayout}>
				<Resource name="Employees" list={EmployeesList} edit={EmployeeEdit} create={EmployeeCreate} icon={UserIcon}/>
				<Resource name="Companies" list={CompaniesList} edit={CompanyEdit} create={CompanyCreate} icon={UserIcon}/>
				<Resource name="Countries" list={CountriesList} edit={CountryEdit} create={CountryCreate} icon={UserIcon}/>
				<Resource name="Branches" list={BranchesList} edit={BranchEdit} create={BranchCreate} icon={UserIcon}/>
				<Resource name="Localizations" list={LocalizationsList} edit={LocalizationEdit} icon={UserIcon}/>
			</Admin>
		</div>
	);

	function _onAction(e) {
		console.log("user did something", e);
	}

	function _onActive(e) {
		console.log("user is active", e);
		console.log("time remaining", idleTimer.getRemainingTime());
	}

	function _onIdle(e) {
		console.log("user is idle", e);
		console.log("last active", idleTimer.getLastActiveTime());
	}
};

export default App;
