import React from "react";
import { useMediaQuery } from "@material-ui/core";
import UnixDateField from "../Components/UnixDateField"
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	TextInput,
	BooleanField,
	BooleanInput,
	Filter
} from "react-admin";

const EmployeeFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="username" alwaysOn />
		<BooleanInput source="isActive" defaultValue={true} />
	</Filter>
);

const EmployeesList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<EmployeeFilter />} {...props}>
			{isSmall ? (
				<SimpleList
					primaryText={(record) => record.username}
					secondaryText={(record) => {
						return record.isActive ? "active" : "inactive";
					}}
				/>
			) : (
				<Datagrid rowClick="edit">
					<UnixDateField source="created"/>
					<TextField source="username" />
					<BooleanField source="isActive" />
				</Datagrid>
			)}
		</List>
	);
};

export default EmployeesList;