import { Box, Dialog, DialogTitle, Button, FormControl,  DialogContent,  Grid, Typography, TextField } from "@mui/material"
import { LocalizationProvider, DatePicker} from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';




interface createTask {
    open: boolean;
    isOpen: (open: boolean) => void
}


const CreateTask = ({ open, isOpen }: createTask) => {
    console.log("kkk:" + open)
    return (
        <Dialog open={open} onClose={() => isOpen(!open)} maxWidth="lg" >
            <DialogTitle>Create Task</DialogTitle>
            <DialogContent>
                <FormControl>
                    <Grid container spacing={2}> {/* Container for the side-by-side elements */}
                        <Grid> {/* Item 1 occupying half the width */}
                            <Typography>Task Name:</Typography>
                        </Grid>
                        <Grid> {/* Item 2 occupying the other half */}
                            <TextField id="taskName" label="Input" />
                        </Grid>
                    </Grid>
                    <Grid container spacing={2}> {/* Container for the side-by-side elements */}
                        <Grid> {/* Item 1 occupying half the width */}
                            <Typography>Task Desciption:</Typography>
                        </Grid>
                        <Grid> {/* Item 2 occupying the other half */}
                            <TextField id="taskDesciption" label="Input" />
                        </Grid>
                    </Grid>
                    <Grid container spacing={2}> {/* Container for the side-by-side elements */}
                        <Grid> {/* Item 1 occupying half the width */}
                            <Typography>Due Date:</Typography>
                        </Grid>
                        <Grid> {/* Item 2 occupying the other half */}
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                <DatePicker label="date" />
                            </LocalizationProvider>
                        </Grid>
                    </Grid>
                    <Grid container spacing={2}> {/* Container for the side-by-side elements */}
                        <Grid> {/* Item 1 occupying half the width */}
                            <Typography>Comments:</Typography>
                        </Grid>
                        <Grid> {/* Item 2 occupying the other half */}
                            <TextField id="Comments" label="Input" />
                        </Grid>
                    </Grid>
                </FormControl>
            </DialogContent>
            <Box display="flex" justifyContent="center" alignItems="center">
                <Button>create</Button>
                <Button>cancel</Button>
            </Box>

        </Dialog>
    )
}

export default CreateTask
