import React from "react";
import { useMediaQuery } from "@material-ui/core";
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	Edit,
	SimpleForm,
	TextInput,
	Create,
	Filter,
	required,
} from "react-admin";

const CountriesFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="name" alwaysOn />
	</Filter>
);

export const CountriesList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<CountriesFilter />} {...props}>
			{isSmall ? (
				<SimpleList primaryText={(record) => record.name} />
			) : (
				<Datagrid rowClick="edit">
					<TextField source="name" />
				</Datagrid>
			)}
		</List>
	);
};

const CountriesTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.name}"` : ""}</span>;
};

export const CountriesEdit = (props) => (
	<Edit title={<CountriesTitle />} {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
		</SimpleForm>
	</Edit>
);

export const CountriesCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
		</SimpleForm>
	</Create>
);
