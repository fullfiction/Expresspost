import React from "react";
import {
	SimpleForm,
	TextInput,
	Create,
	BooleanInput,
	PasswordInput,
	required,
} from "react-admin";

const EmployeeCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="username" validate={required()} />
			<PasswordInput source="password" validate={required()} />
			<BooleanInput source="isActive" defaultValue={true} />
		</SimpleForm>
	</Create>
);

export default EmployeeCreate;