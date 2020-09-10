import React from "react";
import {
	Create,
	SimpleForm,
	ReferenceInput,
	TextInput,
	SelectInput,
	required
} from "react-admin";

const CompanyCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
			<ReferenceInput source="parentId" reference="Companies">
				<SelectInput optionText="name" />
			</ReferenceInput>
		</SimpleForm>
	</Create>
);

export default CompanyCreate;