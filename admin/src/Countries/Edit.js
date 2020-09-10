import React from "react";
import {
	Edit,
	SimpleForm,
	TextInput,
	required,
} from "react-admin";

const CountryTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.name}"` : ""}</span>;
};

const CountryEdit = (props) => (
	<Edit title={<CountryTitle />} {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
		</SimpleForm>
	</Edit>
);

export default CountryEdit;