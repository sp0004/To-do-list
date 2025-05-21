import { Button, Paper, Table, TableBody, TableCell, TableHead, TableRow } from "@mui/material"
import CreateTask from "./create"



function Dashboard() {
    const list_of_tasks = [{ "task": "first task", "due date": "today" }, { "task": "second task", "due date": "tomorrow" }]
    return (
        <div>
            <h1>
                To Do list
            </h1>
            <div>
                <Button onClick={() => CreateTask(true)}>Create tasks</Button>
            </div>
            <div>
                <Paper sx={{ height: '100%', width: '100%' }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Task Name</TableCell>
                                <TableCell> Due Date</TableCell>
                                <TableCell> Created Date</TableCell>
                                <TableCell> Comments</TableCell>
                                <TableCell> Update</TableCell>
                                <TableCell> Delete</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {list_of_tasks.map(a => <TableRow><TableCell>{a.task}</TableCell></TableRow>)}
                        </TableBody>

                    </Table>
                </Paper>
            </div>
        </div>
    )
}

export default Dashboard
