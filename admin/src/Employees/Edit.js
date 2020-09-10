import React from "react";
import {
	Edit,
	SimpleForm,
	TextInput,
	BooleanInput,
	required,
} from "react-admin";

const EmployeeTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.username}"` : ""}</span>;
};

const EmployeeEdit = (props) => (
	<Edit title={<EmployeeTitle />} {...props}>
		<SimpleForm>
			<TextInput source="username" validate={required()} />
			<BooleanInput source="isActive" />
		</SimpleForm>
	</Edit>
);

export default EmployeeEdit;