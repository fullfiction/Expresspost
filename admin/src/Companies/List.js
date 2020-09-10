import React from "react";
import { useMediaQuery } from "@material-ui/core";
import UnixDateField from "../Components/UnixDateField"
import {
	List,
	SimpleList,
	Datagrid,
	TextField,
	ReferenceField,
	TextInput,
	Filter,
	SingleFieldList,
	ChipField,
	ReferenceManyField
} from "react-admin";

const CompaniesFilter = (props) => (
	<Filter {...props}>
		<TextInput label="Search" source="name" alwaysOn />
	</Filter>
);

const CompaniesList = (props) => {
	const isSmall = useMediaQuery((theme) => theme.breakpoints.down("sm"));
	return (
		<List filters={<CompaniesFilter />} {...props}>
			{isSmall ? (
				<SimpleList primaryText={(record) => record.name} />
			) : (
				<Datagrid rowClick="edit">
					<UnixDateField source="created" />
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

export default CompaniesList;