import React from "react";
import { useMediaQuery } from "@material-ui/core";
import UnixDateField from "../Components/UnixDateField"
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	TextInput,
	Filter
} from "react-admin";

const CountriesFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="name" alwaysOn />
	</Filter>
);

const CountriesList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<CountriesFilter />} {...props}>
			{isSmall ? (
				<SimpleList primaryText={(record) => record.name} />
			) : (
				<Datagrid rowClick="edit">
					<UnixDateField source="created"/>
					<TextField source="name" />
				</Datagrid>
			)}
		</List>
	);
};

export default CountriesList;