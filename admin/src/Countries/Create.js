import React from "react";
import {
	SimpleForm,
	TextInput,
	Create,
	required,
} from "react-admin";

const CountryCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
		</SimpleForm>
	</Create>
);

export default CountryCreate;