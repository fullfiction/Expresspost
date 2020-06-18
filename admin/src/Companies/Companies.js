import React from "react";
import { useMediaQuery } from "@material-ui/core";
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	Edit,
	SimpleForm,
	ReferenceInput,
	ReferenceField,
	TextInput,
	SelectInput,
	Create,
	Filter,
	required,
	SingleFieldList,
	ChipField,
	ReferenceManyField
} from "react-admin";

const CompaniesFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="name" alwaysOn />
	</Filter>
);

export const CompaniesList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<CompaniesFilter />} {...props}>
			{isSmall ? (
				<SimpleList primaryText={(record) => record.name} />
			) : (
				<Datagrid rowClick="edit">
					<TextField source="name" />
					<ReferenceField source="parentId" reference="Companies">
						<TextField source="name" />
					</ReferenceField>
					<ReferenceManyField
						label="Child Companies"
						reference="Companies"
						target="parentId"
					>
						<SingleFieldList>
							<ChipField source="name" />
						</SingleFieldList>
					</ReferenceManyField>
				</Datagrid>
			)}
		</List>
	);
};

const CompaniesTitle = ({ record }) => {
	return <span>Edit {record ? `"${record.name}"` : ""}</span>;
};

export const CompaniesEdit = (props) => (
	<Edit title={<CompaniesTitle />} {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
			<ReferenceInput source="parentId" reference="Companies">
				<SelectInput optionText="name" />
			</ReferenceInput>
		</SimpleForm>
	</Edit>
);

export const CompaniesCreate = (props) => (
	<Create {...props}>
		<SimpleForm>
			<TextInput source="name" validate={required()} />
			<ReferenceInput source="parentId" reference="Companies">
				<SelectInput optionText="name" />
			</ReferenceInput>
		</SimpleForm>
	</Create>
);
