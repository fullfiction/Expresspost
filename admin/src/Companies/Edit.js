import React from "react";
import {
	Edit,
	SimpleForm,
	ReferenceInput,
	TextInput,
	SelectInput,
	required
} from "react-admin";


const CompanyTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.name}"` : ""}</span>;
};

const CompanyEdit = (props) => (
	<Edit title={<CompanyTitle />} {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
			<ReferenceInput source="parentId" reference="Companies">
				<SelectInput optionText="name" />
			</ReferenceInput>
		</SimpleForm>
	</Edit>
);

export default CompanyEdit;